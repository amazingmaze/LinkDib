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
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public Link Link { get; set; }

        public NotificationType Type { get; set; }

    }
}