using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Bitly.Models
{
    public class Url
    {

        public int Id { get; set; }
        
        // [Required(ErrorMessage = "Please enter a URL.")]
        // [RegularExpression(@"((http|https|ftp)://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Please enter a valid URL.")]
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        // public int Hits { get; set; }
        public DateTime GeneratedAt { get; set; }
        // public DateTime ExpAt { get; set; }
    }
}