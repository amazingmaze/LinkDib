using System.ComponentModel.DataAnnotations;

namespace LinkDib.Models
{
    public class LinkMessage
    {
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        public LinkMessage(string message)
        {
            Message = message;
        }
    }
}