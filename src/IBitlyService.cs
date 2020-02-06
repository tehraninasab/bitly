

namespace Bitly
{
    public interface IBitlyService
    {
      public string GetRandomUrlEndpoint();

      public string AddUrl(string longUrl);

      public string GetRedirectUrl(string endpoint);

      public string GetLongUrl(string shortEndpoint);

    }
}