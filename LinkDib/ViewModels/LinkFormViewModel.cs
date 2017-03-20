using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LinkDib.Models;
using LinkDib.Validation;

namespace LinkDib.ViewModels
{
    public class LinkFormViewModel
    {
        public ApplicationUser User { get; set; }

        [Required]
        [UrlValidation]
        public string Url { get; set; }

        [Required]
        public string Message { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Thumbnail { get; set; }
    }
}