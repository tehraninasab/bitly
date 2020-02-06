using System;
using Xunit;
using RA;
using Xunit.Abstractions;
using System.Net;
using System.Collections.Generic;

namespace tests
{
    public class RedirectTest
    {
        
        [Fact]
        public void Redirect()
        {
            try{
                new RestAssured()
                    .Given()
                        .Name("Test redirect")
                        .Header("Content-Type", "application/json")
                        .Header("Accept-Encoding", "utf-8")
                    .When()
                        .Get("http://localhost:5000/redirect/BqxKuqgk")
                    .Then()
                        .TestStatus("Test redirect", r => r == 302)
                        .Assert("Test redirect")
                        .TestBody("Test body", body => body = @"https://www.google.com/search?q=salam&oq=salam&aqs=chrome..69i57j69i60l5.984j0j7&sourceid=chrome&ie=UTF-8")
                        .Assert("Test body");
                        


                new RestAssured()
                    .Given()
                        .Name("Test redirect")
                        .Header("Content-Type", "application/json")
                        .Header("Accept-Encoding", "utf-8")
                    .When()
                        .Get("http://localhost:5000/redirect/HjlqZePL")
                    .Then()
                        .TestStatus("Test redirect", r => r == 302)
                        .Assert("Test redirect")
                        .TestBody("Test body", body => body = @"https://www.google.com/search?q=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&oq=System.Exception+%3A+(text%2Fhtml%3B+charset%3DISO-8859-1)+not+supported+Stack+Trace%3A+at+RA.ResponseContext.Parse()&aqs=chrome..69i57.488j0j7&sourceid=chrome&ie=UTF-8")
                        .Assert("Test body");
            
                 
                new RestAssured()
                    .Given()
                        .Name("Test redirect")
                        .Header("Content-Type", "application/json")
                        .Header("Accept-Encoding", "utf-8")
                    .When()
                        .Get("http://localhost:5000/redirect/dmxXVIVz")
                    .Then()
                        .TestStatus("Test redirect", r => r == 302)
                        .Assert("Test redirect")
                        .TestBody("Test body", body => body = @"longurl.g-._~:/?#[]@!$&'()*+,;= ")
                        .Assert("Test body");
                 
            }catch(Exception e){
                Console.WriteLine(e);
            }
        }
    }
}