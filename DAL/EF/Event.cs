using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RSVP> RSVPs { get; set; }

        public Event()
        {
            RSVPs = new HashSet<RSVP>();
        }
    }
}
