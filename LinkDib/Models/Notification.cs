using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkDib.Models
{
    // Temporary. Could be changed to a class later
    public enum NotificationType
    {
        LinkNew = 0,
        LinkUpdated = 1
    }

    public class Notification
    {
        public int Id { get; private set; }

        public ApplicationUser User { get; private set; }

        public string UserId { get; private set; }

        [Required]
        public Link Link { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime DateTime { get; private set; }

        // Needed for Entity framework
        protected Notification()
        {

        }

        public Notification(string userId, Link link, NotificationType type)
        {
            UserId = userId;
            Link = link;
            Type = type;
            DateTime = DateTime.Now;
        }

    }
}