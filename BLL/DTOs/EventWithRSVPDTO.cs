using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventWithRSVPDTO : EventDTO
    {
        public List<EventRSVPDTO> RSVPs { get; set; }

        public EventWithRSVPDTO()
        {
            RSVPs = new List<EventRSVPDTO>();
        }
    }
}
