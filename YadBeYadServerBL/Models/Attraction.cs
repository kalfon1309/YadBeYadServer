using System;
using System.Collections.Generic;

#nullable disable

namespace YadBeYadServerBL.Models
{
    public partial class Attraction
    {
        public Attraction()
        {
            Favorites = new HashSet<Favorite>();
            Rates = new HashSet<Rate>();
            Reviews = new HashSet<Review>();
        }

        public int AttractionId { get; set; }
        public string AttName { get; set; }
        public string AttDescription { get; set; }
        public string AttLocation { get; set; }
        public string GeographyLoc { get; set; }
        public bool IsPrice { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
