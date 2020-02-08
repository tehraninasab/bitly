using Microsoft.AspNetCore.Mvc;
using Bitly.Models;
using System.Text.RegularExpressions;
using System;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

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
        
        // GET this method redirects to the actual URL
        [HttpGet]
        [Route("redirect/{shortUrl}")]
        public IActionResult Get(string shortUrl){
            string url = _service.GetLongUrl(shortUrl);
            if(url == null){
               return StatusCode(404);
            }
            return Redirect(Uri.EscapeUriString(url));
        } 

        // POST this method receives a url and returns a short url for redirect request.
        [HttpPost]
        [Route("bitly")]
        public IActionResult PostLongUrl(Url url){     
            if(!_service.CheckValidUrl(url.LongUrl)){
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
