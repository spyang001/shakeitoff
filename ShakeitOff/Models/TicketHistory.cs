using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShakeitOff.Models
{
    public class TicketHistory
    {
        public virtual Ticket Ticket { get; set; }
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Property { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Changed { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser Users { get; set; }
    }
}