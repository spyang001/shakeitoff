using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShakeitOff.Models
{
    public class Ticket
    {
        // properties of the ticket - these turn into columns in SQL
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public int ProjectId { get; set; }

        public int TicketTypeId { get; set; }

        public int TicketPriortiyId { get; set; }

        public int TicketStatusId { get; set; }

        public string OwnerUserId { get; set; }
        public string AssignedToUserId { get; set; }

        // collection models stored in database
        public Ticket()
        {
            this.TicketAttachments = new HashSet<TicketAttachment>();
            this.TicketComments = new HashSet<TicketComment>();
            this.TicketHistories = new HashSet<TicketHistory>();
            this.TicketNotifications = new HashSet<TicketNotification>();
        
        }

        // navigational properties for our childern - these do not end up as SQL columns...
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketComment>TicketComments { get; set; }
        public virtual ICollection<TicketHistory>TicketHistories { get; set; }
        public virtual ICollection<TicketNotification>TicketNotifications { get; set; }

        // two connections to the user table to track owner and assgined to
        public virtual ApplicationUser OwnerUser { get; set; }
        public virtual ApplicationUser AssignedToUser { get; set; }


        // navigational properties for our parent
        public virtual Project Project { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public virtual TicketType TicketType { get; set; }


    }
}