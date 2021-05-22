using BaiduBce.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BaiduBce.Services.SMS.Model
{
    public class SendSMSRequest: BceRequestBase
    {
        public string SignatureId { get; set; }

        public string Template { get; set; }

        public string Mobile { get; set; }

        public Dictionary<string, string> ContentVar { get; set; } = new Dictionary<string, string>();

        public string ContentJson
        {
            get
            {
                return (ContentVar == null || ContentVar.Count == 0) ? "" : "{" + string.Join(",", ContentVar.Select(kvp => $"\"{kvp.Key}\":\"{kvp.Value}\"").ToArray()) + "}";
            }
        }

        public string ToJsonString()
        {
            var contentJson = ContentJson;
            return $"{{\"signatureId\":\"{SignatureId}\",\"mobile\":\"{Mobile}\",\"template\":\"{Template}\" {(string.IsNullOrEmpty(contentJson) ? "" : ",\"contentVar\":" + contentJson)}}}";
        }

        public Stream GetConentStream()
        {
            string Content = ToJsonString();
            byte[] ContentByte = Encoding.UTF8.GetBytes(Content);
            MemoryStream st = new MemoryStream(ContentByte);
            return st;
        }
    }
}
