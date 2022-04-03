 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YadBeYadServerBL.Models
{
    partial class YadBeYadDBContext : DbContext
    {
        public List<Attraction> GetAttractions()
        {
            List<Attraction> attractions = this.Attractions.ToList<Attraction>();
            return attractions;
        }

        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.Rates)
                .Include(uc => uc.Reviews)
                .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }

        // Sign Up for Client

        public bool SignUp(User u)
        {
          
            if(u != null)
            {
                this.Users.Add(u);
                this.SaveChanges();
                return true;
            }

            return false;

        }



        // a function that checks that the inserted email and user name are unique

        public bool CheckUniqueness(string email, string userName)
        {
            User user = this.Users.Where(u => u.Email == email || u.UserName == userName).FirstOrDefault();

            if (user == null)//the email and the user name are unique
            {
                return true;
            }
            else//one or both are not unique
            {
                return false;
            }
        }



    }
}
