using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Cuo.Training.Web.MathApiProxy
{
    public class MathApiClient
    {
        public string DoPost(string url, string formBody)
        {
            return DoPost(url, "application/json", formBody);
        }

        public string DoPost(string url, string contentType, string formBody)
        {
            var request = CreateWebRequest(url, "POST", contentType, formBody);

            return GetResponseAsString(request);
        }

        public string DoPatch(string url, string formBody)
        {
            var request = CreateWebRequest(url, "PATCH", "application/json", formBody);

            return GetResponseAsString(request);
        }

        public string DoPut(string url, string formBody)
        {
            var request = CreateWebRequest(url, "PUT", "application/json", formBody);

            return GetResponseAsString(request);
        }

        public string DoGet(string url, string contentType)
        {
            var request = CreateWebRequest(url, "GET");

            return GetResponseAsString(request);
        }

        private WebRequest CreateWebRequest(string url, string method, string contentType, string formBody)
        {
            var send = Encoding.Default.GetBytes(formBody);

            var request = WebRequest.Create(url);
            request.Method = method;
            request.ContentType = contentType;
            request.ContentLength = send.Length;

            var reqStream = request.GetRequestStream();
            reqStream.Write(send, 0, send.Length);
            reqStream.Flush();
            reqStream.Close();

            return request;
        }

        private WebRequest CreateWebRequest(string url, string method)
        {
            var request = WebRequest.Create(url);
            request.Method = method;

            return request;
        }

        private string GetResponseAsString(WebRequest request)
        {
            try
            {
                using (var response = request.GetResponse())
                {
                    var sr = new StreamReader(response.GetResponseStream());
                    return sr.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                using (var response = ex.Response)
                {
                    using (var data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}