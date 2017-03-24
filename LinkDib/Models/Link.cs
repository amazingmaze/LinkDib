using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using LinkDib.ViewModels;

namespace LinkDib.Models
{
    public enum Permissions
    {
        Public = 0,
        Private = 1,
        FollowersOnly = 2
    }

    public class Link
    {
        public int Id { get; private set; }

        [Required]
        public string Url { get; set; }

        // Navigation property
        public ApplicationUser User { get; private set; }

        [Required]
        public string UserId { get; private set; }

        public DateTime DateTime { get; private set; }

        public string Message { get; set; }

        // Navigation property
        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string Thumbnail { get; set; }

        [Required]
        public Permissions Permission { get; set; }

        public bool IsDeleted { get; private set; }


        // Needed for Entity framework
        protected Link()
        {

        }

        public Link(string url, string userId, string message, int categoryId, Permissions permission)
        {
            Url = url;
            UserId = userId;
            Message = message;
            CategoryId = categoryId;
            Permission = permission;
            DateTime = DateTime.Now;
            Thumbnail = "TempThumb";
        }

        public void Delete()
        {
            IsDeleted = true;
        }


    }


}
