using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Bitly.Models;
using System.Text.RegularExpressions;
using System.Web;
using System.Text;
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

      // Generate a random base52 string in length 8 that is used for short url end point.
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

      // Add a long url with its shortened url to data base using UrlDbContext class.
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

     // Create short url using its endpoint.
      public string GetRedirectUrl(string endpoint){
        return BaseAddress + "/redirect/" +endpoint;
      }

      // Get long url from data base using its short url endpoint(which
      // is generated in GetRandomUrl method while adding the url.).
      public string GetLongUrl(string shortEndpoint){
        try{
           Url url = _context.Urls.Where(u => u.ShortUrl == shortEndpoint).Single();
           return url.LongUrl;
        }
        catch (Exception e){
          Console.WriteLine(e);
           return null;
        }

      }

      // URL validation
      public bool CheckValidUrl(string url){
          string pattern = @"^https?://.*";
          // A more accurate regex pattern to validate url:
          // string pattern = @"([\d\w-.]+?\.(a[cdefgilmnoqrstuwz]|b[abdefghijmnorstvwyz]|c[acdfghiklmnoruvxyz]|d[ejkmnoz]|e[ceghrst]|f[ijkmnor]|g[abdefghilmnpqrstuwy]|h[kmnrtu]|i[delmnoqrst]|j[emop]|k[eghimnprwyz]|l[abcikrstuvy]|m[acdghklmnopqrstuvwxyz]|n[acefgilopruz]|om|p[aefghklmnrstwy]|qa|r[eouw]|s[abcdeghijklmnortuvyz]|t[cdfghjkmnoprtvwz]|u[augkmsyz]|v[aceginu]|w[fs]|y[etu]|z[amw]|aero|arpa|biz|com|coop|edu|info|int|gov|mil|museum|name|net|org|pro)(\b|\W(?<!&|=)(?!\.\s|\.{3}).*?))(\s|$)";
           return (new Regex(pattern)).IsMatch(url);
      }







        

       
    }
}