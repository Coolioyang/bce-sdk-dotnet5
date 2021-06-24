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

        public static SMSBceClientConfiguration Default()
        {
            return new SMSBceClientConfiguration("e0b6afef3bd140bf92b55cdea62c2651", "cb8fb176050e47db9b16a2d8e2f3b7c8");
        }

    }
}
