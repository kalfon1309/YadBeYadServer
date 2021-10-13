using System;
using System.Collections.Generic;



namespace YadBeYadServerBL.Models
{
    public partial class Attraction
    {
        public Attraction()
        {
            Rates = new HashSet<Rate>();
            Reviews = new HashSet<Review>();
        }

        public int AttractionId { get; set; }
        public string AttName { get; set; }
        public string AttDescription { get; set; }
        public string AttLocation { get; set; }
        public string GeographyLoc { get; set; }
        public bool IsPrice { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
