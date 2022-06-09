using KulturniCentar.Data.Models;
using KulturniCentar.Helper;
using KulturniCentar.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KulturniCentar.Controllers
{
    public class LoginController : Controller
    {
        private readonly CoreDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly JWTSettings _jwtsettings;
        private readonly Authorize _authorize;

        public LoginController(CoreDbContext db, IWebHostEnvironment webHostEnvironment, IOptions<JWTSettings> jwtsettings)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _jwtsettings = jwtsettings.Value;
            _authorize = new Authorize(db);

        }

        [HttpPost("Login")] //async Task<ActionResult<UserWithToken>>
        public IActionResult Login(LoginVM kredencijali)
        {
            if(ModelState.IsValid)
            {
                KorisnickiRacun korisnickiRacun = _db.KorisnickiRacun
                                                            .Where(kr => kr.KorisnickoIme == kredencijali.KorisnickoIme
                                                            && kr.Lozinka == kredencijali.Lozinka).FirstOrDefault();

                UserWithToken userWithToken = null;

                if (korisnickiRacun != null)
                {
                    RefreshToken refreshToken = GenerateRefreshToken();
                    //refreshToken.KorisnickiRacunId = korisnickiRacun.Id;
                    //korisnickiRacun.RefreshToken.Add(refreshToken);
                    _db.RefreshToken.Add(refreshToken);
                    _db.SaveChanges();

                    userWithToken = new UserWithToken();
                    userWithToken.KorisnickiRacunId = korisnickiRacun.Id;
                    userWithToken.RefreshToken = refreshToken.Token;
                }
                else
                {
                    TempData["Poruka"] = "Nisu ispravni podaci za prijavu !";
                    return Redirect("/Home/Login");
                }

                if (userWithToken == null)
                {
                    return null;
                }

                userWithToken.AccessToken = GenerateAccessToken(korisnickiRacun.Id);
                //Global.Id = userWithToken.Id;
                Global.Token = userWithToken.AccessToken;
                Global.Role = korisnickiRacun.Uloga;
                Global.KorisnickiRacunId = userWithToken.KorisnickiRacunId;
                _db.UserWithToken.Add(userWithToken);
                _db.SaveChanges();
                return Redirect("/Home/Index");
            }
            TempData["Poruka"] = "Nisu ispravni podaci za prijavu !";
            return Redirect("/Home/Login");
        }

        private RefreshToken GenerateRefreshToken()
        {
            RefreshToken refreshToken = new RefreshToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken.Token = Convert.ToBase64String(randomNumber);
            }
            refreshToken.ExpiryDate = DateTime.UtcNow.AddMonths(6);
            //refreshToken.Id = 1;
            return refreshToken;
        }

        private string GenerateAccessToken(int korisnickiRacunId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Convert.ToString(korisnickiRacunId))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<UserWithToken>> RefreshToken([FromBody] RefreshRequest refreshRequest)
        {
            KorisnickiRacun korisnickiRacun = await GetUserFromAccessToken(refreshRequest.AccessToken);

            if (korisnickiRacun != null && ValidateRefreshToken(korisnickiRacun, refreshRequest.RefreshToken))
            {
                UserWithToken userWithToken = new UserWithToken();
                userWithToken.KorisnickiRacunId = korisnickiRacun.Id;
                userWithToken.AccessToken = GenerateAccessToken(korisnickiRacun.Id);

                return userWithToken;
            }

            return null;
        }

        private bool ValidateRefreshToken(KorisnickiRacun korisnickiRacun, string refreshToken)
        {

            RefreshToken refreshTokenUser = _db.RefreshToken.Where(rt => rt.Token == refreshToken)
                                                .OrderByDescending(rt => rt.ExpiryDate)
                                                .FirstOrDefault();

            if (refreshTokenUser != null && refreshTokenUser.KorisnickiRacunId == korisnickiRacun.Id
                && refreshTokenUser.ExpiryDate > DateTime.UtcNow)
            {
                return true;
            }

            return false;
        }
        private async Task<KorisnickiRacun> GetUserFromAccessToken(string accessToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                SecurityToken securityToken;
                var principle = tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

                JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;

                if (jwtSecurityToken != null && jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    var korisnickoIme = principle.FindFirst(ClaimTypes.Name)?.Value;

                    return  _db.KorisnickiRacun.Where(u => u.KorisnickoIme == korisnickoIme).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return new KorisnickiRacun();
            }

            return new KorisnickiRacun();
        }
        public IActionResult LogOut()
        {
            Global.Role = null;
            Global.KorisnickiRacunId = 0;
            Global.Token = null;
            return Redirect("/Home/Login");
        }
    }
}
