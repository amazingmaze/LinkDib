using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkDib.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; private set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; private set; }

        public bool IsRead { get; set; }

        // Navigation properties
        public ApplicationUser User { get; private set; }
        public Notification Notification { get; private set; }

        // Needed for Entity framework. 
        protected UserNotification()
        {

        }

        // This, along with private set methods will force users & notifcations to not be null
        public UserNotification(ApplicationUser user, Notification notification)
        {
            if (user == null || notification == null)
                throw new ArgumentNullException();

            User = user;
            Notification = notification;
        }

    }
}