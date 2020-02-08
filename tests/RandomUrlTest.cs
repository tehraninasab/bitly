using System;
using Xunit;
using RA;
using Xunit.Abstractions;
using Bitly;
using System.Text.RegularExpressions;
namespace tests
{
    
    public class RandomUrlTest
    {
        [Fact]
        public void CreateRandomUrl(){
            BitlyService service = new BitlyService();
            Regex regex = new Regex(@"^[A-Za-z]{8}$");
            Boolean match = regex.IsMatch(service.GetRandomUrlEndpoint());

            Assert.True(match);
        }

        [Fact]
        public void InvalidUrl(){
            BitlyService service = new BitlyService();
            Regex lowerLengthRegex = new Regex(@"^[A-Za-z]{8:}$");
            Regex higherLengthRegex = new Regex(@"^[A-Za-z]{0:7}$");

            Boolean lowerMatch = lowerLengthRegex.IsMatch(service.GetRandomUrlEndpoint());
            Boolean higherMatch = higherLengthRegex.IsMatch(service.GetRandomUrlEndpoint());

            Assert.False(lowerMatch);
            Assert.False(higherMatch);
        }

        
    }
}