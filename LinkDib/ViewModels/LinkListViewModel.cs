using System.Collections.Generic;
using LinkDib.Models;

namespace LinkDib.ViewModels
{
    public class LinkListViewModel
    {
        public IEnumerable<Link> Links { get; set; }
        public bool Authenticated { get; set; }
    }
}