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
        [Route("redirect/{shortUrl}")]
        public IActionResult Get(string shortUrl){
            string url = _service.GetLongUrl(shortUrl);
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
            
            PostResponse response = new PostResponse(url.LongUrl, _service.GetRedirectUrl(url.ShortUrl));
            return Ok(response);
        }
    }

    public class PostResponse{
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public PostResponse(string longUrl, string shortUrl){
            LongUrl = longUrl;
            ShortUrl = shortUrl;
        }
    }
    
}
