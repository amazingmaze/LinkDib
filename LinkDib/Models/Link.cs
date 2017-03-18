using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace LinkDib.Models
{
    public class Link
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        public LinkMessage Message { get; set; }

        public string LinkCategory { get; set; }

        public string Thumbnail { get; set; }

        public Link()
        {
            //TODO: Get and set user from here instead of controller?

            DateTime = DateTime.Now;
            LinkCategory = "TempCat";
            Thumbnail = "TempThumb";
        }
    }
}
