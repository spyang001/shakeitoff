using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShakeitOff.Models
{
    public class TicketComment
    {
        public virtual Ticket Ticket { get; set; }

        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTimeOffset Created { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        


        public virtual ApplicationUser Users { get; set; }

    }
}