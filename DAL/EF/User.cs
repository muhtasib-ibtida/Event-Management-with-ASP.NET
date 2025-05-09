using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<RSVP> RSVPs { get; set; }

        public User()
        {
            RSVPs = new HashSet<RSVP>();
        }
    }
}
