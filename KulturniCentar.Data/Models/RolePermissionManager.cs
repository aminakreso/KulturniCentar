using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulturniCentar.Data.Models
{
    public class RolePermissionManager
    {
        protected CoreDbContext db;
        protected RolePermissionManager(CoreDbContext context)
        {
            db = context;
        }
        public string ResolveRoleName(string loginName)
        {
            //Retrieve user's information from the database
            KorisnickiRacun foundUser = (from user in db.KorisnickiRacun
                                         where user.KorisnickoIme == loginName
                                         select user).SingleOrDefault();

            if (foundUser == null)
            {
                return new string(" ");
            }

            //Return correspoding roles
            if (foundUser.Uloga == "Admin")
            {
                return "Admin";
            }
            else if (foundUser.Uloga == "Polaznik")
            {
                return "Korisnik";
            }

            return new string(" ");

        }
    }
}
