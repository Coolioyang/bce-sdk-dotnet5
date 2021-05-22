using BaiduBce;
using System;
using BaiduBce.Auth;
using BaiduBce.Services.SMS;
using BaiduBce.Services.SMS.Model;

namespace sms_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            

            const string accessKeyId = "AAAA"; // 用户的Access Key ID
            const string secretAccessKey = "BBBB"; // 用户的Secret Access Key


            BceClientConfiguration config = new BceClientConfiguration();
            config.Credentials = new DefaultBceCredentials(accessKeyId, secretAccessKey);
            config.Endpoint = "https://smsv3.bj.baidubce.com";
            config.SignOptions.HeadersToSign.Add("host");
            config.SignOptions.HeadersToSign.Add("x-bce-date");

            SMSClient client = new SMSClient(config);

            SendSMSRequest req = new SendSMSRequest();
            req.Mobile = "13xxxxxxx";
            req.SignatureId = "sms-sign-xxxx";
            req.Template = "sms-tmpl-xxxxx";
            req.ContentVar.Add("code", "8888"); //模板变量
            client.SendSMS(req);
        }
    }
}
