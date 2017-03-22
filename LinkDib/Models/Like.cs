using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LinkDib.Models
{
    public class Like
    {
        // Navigation property
        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }

        // Navigation property
        public Link Link { get; set; }

        [Key]
        [Column(Order = 2)]
        public int LinkId { get; set; }
    }
}