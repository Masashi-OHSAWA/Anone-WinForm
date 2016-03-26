using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Anone.Components
{
    public class AnoneRequest
    {
        // [{"id":2,"from":"papa","to":"child","type":"audio","message":"Hello","url":"http://13.71.156.156:4567/api/messages/2.wav","created_at":"2016-03-20T15:21:46+09:00"}]
        // [{"id":65,"from":"papa","to":"child","type":"stamp","message":null,"url":"http://13.71.156.156:4567/api/messages/65.png","created_at":"2016-03-26T03:58:41+00:00"}]
        public static IEnumerable<StampMessage> Receive(string user, string since)
        {
            dynamic json = null;
            try
            {
                string query = null;
                if (!string.IsNullOrWhiteSpace(since))
                {
                    query = $"?since={since}";
                }

                Uri url = new Uri(BaseAddress, Uri.EscapeUriString(user) + $"/messages" + query);
                HttpWebRequest req = NewPoster(url, WebRequestMethods.Http.Get, "text/plain");

                // レスポンスの取得と読み込み
                var res = req.GetResponse() as HttpWebResponse;
                Stream resStream = res.GetResponseStream();
                json = DynamicJson.Parse(resStream);
                resStream.Close();
            }
            catch (Exception)
            {
            }
            if (json != null && json.IsArray)
            {
                foreach (var entry in json)
                {
                    yield return new StampMessage()
                    {
                        Type = entry.type,
                        TimeStamp = entry.created_at,
                        From = entry.from,
                        To = entry.to,
                        Url = entry.url,
                    };
                }
            }
        }

        // {"content":{"id":3,"from":"papa","to":"child","type":"audio","message":"Hello","url":null,"created_at":"2016-03-20T06:50:18+00:00"},"post_path":"http://13.71.156.156:4567/api/papa/audios/3","status":"ok"}
        public static void Talk(AudioMessage message)
        {
            try
            {
                Uri url = new Uri(BaseAddress, Uri.EscapeUriString(message.From) + "/audios");
                HttpWebRequest req = NewPoster(url);

                // ポスト・データの書き込み
                var postString = $"to={Uri.EscapeUriString(message.To)}&message={Uri.EscapeUriString(message.Message)}";
                var postBinary = Encoding.ASCII.GetBytes(postString);
                var reqStm = req.GetRequestStream();
                reqStm.Write(postBinary, 0, postBinary.Length);
                reqStm.Close();

                // レスポンスの取得と読み込み
                var res = req.GetResponse() as HttpWebResponse;
                Stream resStream = res.GetResponseStream();
                var json = DynamicJson.Parse(resStream);
                resStream.Close();

                if (json.status == "ok")
                {
                    var id = json.content.id;

                    url = new Uri(json.post_path);
                    req = NewPoster(url, WebRequestMethods.Http.Post, "audio/vnd.wave");

                    // オーディオデータの書き込み
                    reqStm = req.GetRequestStream();
                    message.AudioStream.Seek(0, SeekOrigin.Begin);
                    message.AudioStream.CopyTo(reqStm);
                    reqStm.Close();

                    // レスポンスの取得と読み込み
                    res = req.GetResponse() as HttpWebResponse;
                    resStream = res.GetResponseStream();
                    var jAudio = DynamicJson.Parse(resStream);
                    resStream.Close();
                    if (jAudio.status == "ok")
                    {
                        //MessageBox.Show($"id={id}, message={json.content.message}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show($"id={id}, status={jAudio.status}", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //MessageBox.Show($"status={json.status}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }

        private static HttpWebRequest NewPoster(Uri url)
        {
            return NewPoster(url, WebRequestMethods.Http.Post, "application/x-www-form-urlencoded");
        }

        private static readonly Uri BaseAddress = new Uri("http://13.71.156.156:4567/api/");

        private static HttpWebRequest NewPoster(Uri url, string method, string contentType)
        {
            HttpWebRequest req = HttpWebRequest.CreateDefault(url) as HttpWebRequest;
            req.Method = method;
            req.ContentType = contentType;
            req.SendChunked = false;
            req.ServicePoint.Expect100Continue = false;
            return req;
        }
    }

    public class AudioMessage
    {
        public Stream AudioStream { get; set; }
        public string Message { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    public class StampMessage
    {
        public string Type { get; set; }
        public string TimeStamp { get; set; }
        public string Url { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
