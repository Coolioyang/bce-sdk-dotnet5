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

            var config = new SMSBceClientConfiguration(accessKeyId, secretAccessKey);
            var client = new SMSClient(config);

            var req = new SendSMSRequest();
            req.Mobile = "13xxxxxxx";
            req.SignatureId = "sms-sign-xxxx";
            req.Template = "sms-tmpl-xxxxx";
            req.ContentVar.Add("code", "8888"); //模板变量
            client.SendSMS(req);
        }
    }
}
