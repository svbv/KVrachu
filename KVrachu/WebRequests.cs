using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class WebRequests
    {
        public static System.Net.HttpWebRequest GetGetRequest(string uri, System.Net.CookieContainer cookie = null)
        {
            var req = GetRequest(uri, cookie);
            req.Method = "GET";
            return req;
        }

        public static System.Net.HttpWebRequest GetPostRequest(System.Net.CookieContainer cookie, string uri, string content)
        {
            var req = System.Net.HttpWebRequest.Create(uri) as System.Net.HttpWebRequest;
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            req.Method = "POST";
            req.Host = "mosreg.k-vrachu.ru";
            
            var body = Encoding.UTF8.GetBytes(content);
            req.ContentLength = body.Length;

            req.Headers.Add("Cache-Control", "max-age=0");
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.Headers.Add("Origin", "http://mosreg.k-vrachu.ru");
            req.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.57 Safari/537.36";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Referer = "http://mosreg.k-vrachu.ru/service/record/profiles";
            req.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            req.Headers.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
            req.ServicePoint.Expect100Continue = false;
            req.CookieContainer = cookie;
            
            using (var stream = req.GetRequestStream())
            {
                stream.Write(body, 0, body.Length);
                stream.Close();
            }
            
            return req;
        }

        private static System.Net.HttpWebRequest GetRequest(string uri, System.Net.CookieContainer cookie)
        {
            var req = System.Net.HttpWebRequest.Create(uri) as System.Net.HttpWebRequest;
            req.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            req.CookieContainer = cookie;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            req.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.57 Safari/537.36";
            req.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            req.Headers.Add("Accept-Language", "en-US,en;q=0.8,ru;q=0.6");
            req.KeepAlive = true;
            return req;
        }

        public const string SECOND_STAGE_SIGN = "Для записи к врачу-специалисту другого ЛПУ необходимо иметь электронное направление";
    }
}
