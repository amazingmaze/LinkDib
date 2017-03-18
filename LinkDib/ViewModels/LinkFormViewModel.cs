using System;
using System.ComponentModel.DataAnnotations;
using LinkDib.Models;
using LinkDib.Validation;

namespace LinkDib.ViewModels
{
    public class LinkFormViewModel
    {
        [Required]
        [UrlValidation]
        public string Url { get; set; }

        [Required]
        public string Message { get; set; }

        public string LinkCategory { get; set; }

        public string Thumbnail { get; set; }
    }
}