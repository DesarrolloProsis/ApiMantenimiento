using System;
using System.Collections.Generic;

namespace ApiMantenimiento1.Models
{
    public partial class Dtcusers
    {
        public Dtcusers()
        {
            Dtcdata = new HashSet<Dtcdata>();
            UserSquare = new HashSet<UserSquare>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public int RollId { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }

        public virtual RollsCatalog Roll { get; set; }
        public virtual ICollection<Dtcdata> Dtcdata { get; set; }
        public virtual ICollection<UserSquare> UserSquare { get; set; }
    }
}
