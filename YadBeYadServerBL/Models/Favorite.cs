using System;
using System.Collections.Generic;

#nullable disable

namespace YadBeYadServerBL.Models
{
    public partial class Favorite
    {
        public int FavoriteId { get; set; }
        public int AttractionId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }

        public virtual Attraction Attraction { get; set; }
        public virtual User User { get; set; }
    }
}
