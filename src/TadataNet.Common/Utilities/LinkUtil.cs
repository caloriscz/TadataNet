using System.Diagnostics;
using System.Net;

namespace TadataNet.Common.Utilities;

public static class LinkUtil
{
    public static bool CheckLink(string uri)
    {
        try
        {
            //Setting the Request method HEAD, you can also use GET too. maybe less exhaustive
            //request.Method = "HEAD";

            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            using (var response = request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    return true;
                }
            }
        }
        catch (WebException ex)
        {
            if (ex.Status == WebExceptionStatus.ProtocolError &&
                ex.Response != null)
            {
                var resp = (HttpWebResponse)ex.Response;
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    Trace.WriteLine("Status");
                    return false;
                }
            }
            else
            {
                // Do something else
            }
        }

        return false;
    }
}
