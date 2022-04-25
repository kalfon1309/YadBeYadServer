using System;
using System.Collections.Generic;

#nullable disable

namespace YadBeYadServerBL.Models
{
    public partial class User
    {
        public User()
        {
            Favorites = new HashSet<Favorite>();
            Rates = new HashSet<Rate>();
            Reviews = new HashSet<Review>();
        }

        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
