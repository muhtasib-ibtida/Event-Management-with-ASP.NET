﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class RSVP
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        public bool IsAttending { get; set; }

        public virtual User User { get; set; }
        public virtual Event Event { get; set; }
    }
}
