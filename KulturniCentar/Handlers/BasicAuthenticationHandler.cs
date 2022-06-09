using KulturniCentar.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace KulturniCentar.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly CoreDbContext _db;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock, CoreDbContext db) : base(options, logger, encoder, clock)
            {
                _db = db;
            }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");

            try
            {
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                var bytes = Convert.FromBase64String(authenticationHeaderValue.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");

                string korisnickoIme = credentials[0]; //email
                string password = credentials[1];

                //Korisnik korisnik = _context.Korisnik.Where(korisnik => korisnik.KorisnickiRacun.Email == emailAddress && korisnik.KorisnickiRacun.Password == password).FirstOrDefault();

                KorisnickiRacun korisnickiRacun = _db.KorisnickiRacun.Where(korisnickiRacun =>
                  korisnickiRacun.KorisnickoIme == korisnickoIme && korisnickiRacun.Lozinka == password).FirstOrDefault();

                if (korisnickiRacun == null)
                    return AuthenticateResult.Fail("Invalid user.");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, korisnickiRacun.KorisnickoIme) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

            }
            catch (Exception)
            {
                return AuthenticateResult.Fail("Error has occured.");
            }
            //return AuthenticateResult.Fail("Error.");
        }

    }


}

