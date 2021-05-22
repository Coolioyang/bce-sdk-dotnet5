using BaiduBce.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiduBce.Services.SMS
{
    public class SMSBceClientConfiguration: BceClientConfiguration
    {
        public SMSBceClientConfiguration(string accessKeyId, string secretKey)
        {
            Credentials = new DefaultBceCredentials(accessKeyId, secretKey);
            Endpoint = "https://smsv3.bj.baidubce.com";
            SignOptions.HeadersToSign.Add("host");
            SignOptions.HeadersToSign.Add("x-bce-date");
        }
    }
}
