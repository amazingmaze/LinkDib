using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinkDib.Models
{
    public class UserNotification
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NotificationId { get; set; }

        public bool IsRead { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Notification Notification { get; set; }
    }
}