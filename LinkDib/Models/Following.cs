using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkDib.Models
{
    public class Following
    {
        // Navigation property  
        public ApplicationUser Follower { get; set; }

        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }

        // Navigation property
        public ApplicationUser Followee { get; set; }

        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }
    }
}