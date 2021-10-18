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
        //public string Test()
        //{
        //    return "Achiya's mom is a milf";
        //}

        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.UserContacts)
                .ThenInclude(uc => uc.ContactPhones)
                .Where(u => u.Email == email && u.UserPswd == pswd).FirstOrDefault();

            return user;
        }
    }
}
