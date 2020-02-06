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
            new RestAssured()
                .Given()
                    .Name("Test redirect")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                .When()
                    .Get("http://localhost:5000/bitly/pqVrEQWA")
                .Then()
                    .TestStatus("Test redirect", r => r == 302)
                    .Assert("Test redirect");
                    // .TestBody("Test body", body => {Console.WriteLine("body:"+body); return body == "https://longurl.url";})
                    // .Assert("Test body");


                    
            // Dictionary<string, string> values2 = new Dictionary<string, string>();
            // values2.Add("longUrl", "longurl.url");
            // new RestAssured()
            //     .Given()
            //         .Name("Test receive long url")
            //         .Header("Content-Type", "application/json")
            //         .Header("Accept-Encoding", "utf-8")
            //         .Body(values2)
            //     .When()
            //         .Post("localhost:5000/bitly")
            //     .Then()
            //         .TestStatus("Test receive", r => r == 200)
            //         .Assert("Test receive")
            //         .TestBody("Test body", body => {Console.WriteLine(body); return body == "longurl.url";})
            //         .Assert("Test body");
        }
    }
}