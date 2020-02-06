using Microsoft.AspNetCore.Mvc;
using Bitly.Models;
using System.Text.RegularExpressions;
using System;

namespace Bitly.Controllers
{

    [Route("bitly/{*url}")]
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
        public IActionResult Redirect(){
            string shortUrl = Request.Path;
            string url = _service.GetRedirectUrl(shortUrl);
            
            return Redirect(url);
        } 

        [HttpPost]
        public IActionResult PostLongUrl(){
            
            string urlString = "https:"+HttpContext.Request.Path;
           
            var regex  = new Regex(@"((http|https|ftp)://)?([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
            if(!regex.IsMatch(urlString)){
                return StatusCode(400);
            }

            Url url = new Url();
            url.LongUrl = urlString;
            
            return Ok(url);
        }
    }
    
}
