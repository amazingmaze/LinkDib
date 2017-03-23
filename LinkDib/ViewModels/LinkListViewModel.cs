using System.Collections.Generic;
using System.Linq;
using LinkDib.Models;

namespace LinkDib.ViewModels
{
    public class LinkListViewModel
    {
        public IEnumerable<Link> Links { get; set; }
        public bool Authenticated { get; set; }
        public ILookup<int, Like> Likes { get; set; }
        public ILookup<int, Favorite> Favorites { get; set; }
        public ILookup<string, Following> Followees { get; set; }
    }
}