﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShakeitOff.Models
{
    public class TicketPriority
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        
        public int TicketId { get; set; }

        public TicketPriority()
        {
            this.Tickets = new HashSet<Ticket>();

        }

            public virtual ICollection<Ticket> Tickets { get; set; }
    }
}