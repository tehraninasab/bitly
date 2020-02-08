using Bitly.Models;

namespace Bitly
{
    public interface IBitlyService
    {
      public string GetRandomUrlEndpoint();

      public void AddUrl(Url url);

      public string GetRedirectUrl(string endpoint);

      public string GetLongUrl(string shortEndpoint);

      public bool CheckValidUrl(string url);

    }
}