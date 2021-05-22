# 说明

For自[百度官方C# SDK](http://bce.baidu.com/doc/BOS/Cs-SDK.html#快速入门)，增加了SMS发送服务


# 使用方法
```
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
```