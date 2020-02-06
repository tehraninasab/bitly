using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Bitly.Models;
namespace Bitly
{
    public class BitlyService : IBitlyService
    {
      protected readonly UrlDbContext _context;
      private int ShortUrlLength { get; set; } = 8;
      private string BaseAddress { get; set; } = "http://localhost:5000";
      public BitlyService(UrlDbContext context){
        this._context = context;
      }
      public BitlyService(){}

      public string GetRandomUrlEndpoint(){
        string map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string randomUrl = "";
        Random random = new Random();
        for(int i = 0; i<ShortUrlLength; i++){
          int randomNumber = random.Next(0, map.Length);
          randomUrl += map[randomNumber];
        }

        return randomUrl;
      }

      public string AddUrl(string longUrl){
      
         string shortEndpoint = GetRandomUrlEndpoint();
         while(_context.Urls.Any(o => o.ShortUrl == shortEndpoint)){
            shortEndpoint = GetRandomUrlEndpoint();
         }

         Url url = new Url();
         url.LongUrl = longUrl;
         url.ShortUrl = shortEndpoint;
         url.GeneratedAt = System.DateTime.Now;

          _context.Urls.Add(url);
          _context.SaveChanges();

          return GetRedirectUrl(shortEndpoint);
      }

      public string GetRedirectUrl(string endpoint){
        return BaseAddress + "/redirect/" +endpoint;
      }

      public string GetLongUrl(string shortEndpoint){
        try{
           Url url = _context.Urls.Where(u => u.ShortUrl == shortEndpoint).Single();
           return url.LongUrl;
        }
        catch{
           return null;
        }

      }







        

       
    }
}
