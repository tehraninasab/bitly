using Microsoft.AspNetCore.Mvc;
using Bitly.Models;
using System.Text.RegularExpressions;
using System;

namespace Bitly.Controllers
{

    
    [Produces("application/json")]
    [ApiController]
    public class BitlyController : ControllerBase 
    {
        private readonly IBitlyService _service;

        public BitlyController(IBitlyService service){
            _service = service;
        }
        // GET api/values
        [HttpGet]
        [Route("bitly/{shortUrl}")]
        public IActionResult Get(string shortUrl){
            // string shortUrl = Request.Path;
            Console.WriteLine("Url: " + shortUrl);
            Console.WriteLine(_service);
            string url = _service.GetLongUrl(shortUrl);
            Console.WriteLine("longUrl:"+url);
           if(url == null){
               return StatusCode(404);
           }

            return Redirect(url);
        } 

        [HttpPost]
        [Route("bitly")]
        public IActionResult PostLongUrl(Url url){
                    
            var regex  = new Regex(@"((http|https|ftp)://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            if(!regex.IsMatch(url.LongUrl)){
                return StatusCode(400);
            }

            _service.AddUrl(url);
            
          
            return Ok(url);
            
            
        }
    }

    public class PostResponse{
        string LongUrl { get; set; }
        string ShortUrl { get; set; }
        public PostResponse(){}

        public PostResponse(string longUrl, string shortUrl){
            LongUrl = longUrl;
            ShortUrl = shortUrl;
        }
    }
    
}
