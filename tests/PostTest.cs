using System;
using Xunit;
using RA;
using Xunit.Abstractions;
using System.Net;
using System.Collections.Generic;

namespace tests
{
    public class PostTest
    {
        [Fact]
        public void ReceiveLongUrl()
        {
             
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("longUrl", "https://longurl.url");

            new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values)
                .When()
                    .Post("localhost:5000/bitly")
                                 
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .Assert("Test receive")
                    .TestBody("Test body", body =>  body.longUrl == "https://longurl.url")
                    .Assert("Test body");


                    
            Dictionary<string, string> values2 = new Dictionary<string, string>();
            values2.Add("longUrl", "longurl.url");
            new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values2)
                .When()
                    .Post("localhost:5000/bitly")
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .Assert("Test receive")
                    .TestBody("Test body", body => body.longUrl == "longurl.url")
                    .Assert("Test body");
        }


        [Fact]
        public void ReceiveSpecialChars()
        {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("longUrl", "longurl.g-._~:/?#[]@!$&'()*+,;=");

               new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values)
                .When()
                    .Post("localhost:5000/bitly")
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .TestBody("Test special chars", r => r.longUrl == "longurl.g-._~:/?#[]@!$&'()*+,;=")
                    
                .Assert("Test receive")
                .Assert("Test special chars");     



                Dictionary<string, string> values2 = new Dictionary<string, string>();
                values2.Add("longUrl", "https://www.salam.com.url.com/zahra/hasan#maryam/فا؟رسی?q=asghar");

               new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(values2)
                .When()
                    .Post("localhost:5000/bitly")
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .TestBody("Test special chars", r => r.longUrl == "https://www.salam.com.url.com/zahra/hasan#maryam/فا؟رسی?q=asghar")
                    
                .Assert("Test receive")
                .Assert("Test special chars");                
     
        }

    


    }
}
