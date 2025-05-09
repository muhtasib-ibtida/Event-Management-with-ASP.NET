using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RSVPDTO
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public bool IsAttending { get; set; }
        public string Name { get; set; }
        public string EventTitle { get; set; }
    }
}
