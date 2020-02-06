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

      public void AddUrl(Url url){
      
         string shortEndpoint = GetRandomUrlEndpoint();
         while(_context.Urls.Any(o => o.ShortUrl == shortEndpoint)){
            shortEndpoint = GetRandomUrlEndpoint();
         }

         url.ShortUrl = shortEndpoint;
         url.GeneratedAt = System.DateTime.Now;

          _context.Urls.Add(url);
          _context.SaveChanges();
      }

      public string GetRedirectUrl(string endpoint){
        return BaseAddress + "/redirect/" +endpoint;
      }

      public string GetLongUrl(string shortEndpoint){
        try{
          Console.WriteLine("In try");
           Url url = _context.Urls.Where(u => u.ShortUrl == shortEndpoint).Single();
           Console.WriteLine("after context");
            return url.LongUrl;
        }
        catch (Exception e){
          Console.WriteLine(e);
           return null;
        }

      }







        

       
    }
}
