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
        [Theory]
        [JsonFileData("TestFiles/redirectdata.json")]
        public void Redirect(string shortEndpoint, string longUrl)
        {
            string shortUrl = "http://localhost:5000/redirect"+shortEndpoint;
        
            new RestAssured()
                .Given()
                    .Name("Test redirect")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                .When()
                    .Get(shortUrl)
                .Then()
                    .TestStatus("Test redirect", r => r == 302)
                    .Assert("Test redirect");
            //         // .TestBody("Test body", body => body = longUrl)
            //         // .Assert("Test body");
           

        }
    }
}