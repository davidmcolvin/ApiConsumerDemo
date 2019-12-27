using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
  public class SunProcessor
  {
    public static async Task<SunModel> LoadSun(int comicNumber = 0)
    {
      string url = "https://api.sunrise-sunset.org/json?lat=42.288750&lng=-85.418310=today";

      using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
      {
        if (response.IsSuccessStatusCode)
        {
          SunResultModel results = await response.Content.ReadAsAsync<SunResultModel>();

          return results.Results;
        }
        else
        {
          throw new Exception(response.ReasonPhrase);
        }
      }
    }
  }
}
