using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventRSVPDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public bool IsAttending { get; set; }
    }
}
