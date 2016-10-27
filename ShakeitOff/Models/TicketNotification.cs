using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShakeitOff.Models
{
    public class TicketNotification
    {
        public virtual Ticket Ticket { get; set; }
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser Users { get; set; }
    }
}