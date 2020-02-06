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
                    .TestStatus("Test receive 1", r => r == 200)
                    .Assert("Test receive 1")
                    .TestBody("Test body 1", body => body.longUrl == "https://longurl.url")
                    .Assert("Test body 1");


                    
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
                    .TestStatus("Test receive 2", r => r == 200)
                    .Assert("Test receive 2")
                    .TestBody("Test body 2", body => body.longUrl == "longurl.url")
                    .Assert("Test body 2");
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


                Dictionary<string, string> values3 = new Dictionary<string, string>();
                values3.Add("longUrl", "https://www.google.com/search?q=salam&oq=salam&aqs=chrome..69i57j69i60l5.984j0j7&sourceid=chrome&ie=UTF-8");

                new RestAssured()
                    .Given()
                        .Name("Test receive long url")
                        .Header("Content-Type", "application/json")
                        .Header("Accept-Encoding", "utf-8")
                        .Body(values3)
                    .When()
                        .Post("localhost:5000/bitly")
                    .Then()
                        .TestStatus("Test receive", r => r == 200)
                        .TestBody("Test special chars", r => r.longUrl == "https://www.google.com/search?q=salam&oq=salam&aqs=chrome..69i57j69i60l5.984j0j7&sourceid=chrome&ie=UTF-8")
                        
                    .Assert("Test receive")
                    .Assert("Test special chars"); 


                Dictionary<string, string> values4 = new Dictionary<string, string>();
                values4.Add("longUrl", @"https://www.google.com/search?q=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&oq=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&aqs=chrome..69i57.488j0j7&sourceid=chrome&ie=UTF-8");

                new RestAssured()
                    .Given()
                        .Name("Test receive long url")
                        .Header("Content-Type", "application/json")
                        .Header("Accept-Encoding", "utf-8")
                        .Body(values4)
                    .When()
                        .Post("localhost:5000/bitly")
                    .Then()
                        .TestStatus("Test receive", r => r == 200)
                        .TestBody("Test special chars", r => r.longUrl == @"https://www.google.com/search?q=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&oq=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&aqs=chrome..69i57.488j0j7&sourceid=chrome&ie=UTF-8")
                        
                    .Assert("Test receive")
                    .Assert("Test special chars"); 

        }

    


    }
}
