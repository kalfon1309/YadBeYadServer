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
        

        public User Login(string email, string pswd)
        {
            User user = this.Users
                .Include(us => us.Rates)
                .Include(uc => uc.Reviews)
                .Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }
    }
}
