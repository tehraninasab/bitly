using System;
using Xunit;
using RA;
using Xunit.Abstractions;
using System.Net;

namespace tests
{
    public class PostTest
    {
        [Fact]
        public void ReceiveLongUrl()
        {
            // string url = "localhost:5000/bitly/longurl";
            new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                .When()
                    .Post("localhost:5000/bitly/longurl")
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .TestBody("Test body", (r) => {
                                Console.WriteLine("urrrrrl:"+r.LongUrl+"end");
                                return r.LongUrl == "/bitly/longurl";})
                
                .Assert("Test receive")
                .Assert("Test body");
        }


        [Fact]
        public void ReceiveSpecialChars()
        {
               new RestAssured()
                .Given()
                    .Name("Test receive long url")
                    .Header("Content-Type", "application/json")
                    .Header("Accept-Encoding", "utf-8")
                .When()
                    .Post("localhost:5000/bitly/-._~:/?#[]@!$&'()*+,;=")
                .Then()
                    .TestStatus("Test receive", r => r == 200)
                    .TestBody("Test special chars", r => r.LongUrl == "/bitly/-._~:/?#[]@!$&'()*+,;=")
                    
                .Assert("Test receive")
                .Assert("Test special chars");                   
     
        }

    


    }
}
