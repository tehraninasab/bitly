using System;
using Xunit;
using RA;
using Xunit.Abstractions;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace tests
{
    public class PostTest
    {
        [Theory]
        [JsonFileData("TestFiles/postdata.json", "ValidData")]
        public void PostLongUrl(string url)
        {

            Dictionary<string, string> body = new Dictionary<string, string>()
            {
                {"longUrl", url}
            };

            new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(body)
                .When()
                    .Post("localhost:5000/bitly")
                                 
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .Assert("Test receive")
                    .TestBody("Test long url", b => b.longUrl == url)
                    .Assert("Test long url");
                  
        }

        [Theory]
        [JsonFileData("TestFiles/postdata.json", "InvalidData")]
        public void InvalidLongUrl(string url)
        {
            Dictionary<string, string> body = new Dictionary<string, string>()
            {
                {"longUrl", url}
            };

            new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                    .Body(body)
                .When()
                    .Post("localhost:5000/bitly")
                                 
                .Then()
                    .TestStatus("Test receive", r => r == 400)
                    .Assert("Test receive");
        }


    }
}
