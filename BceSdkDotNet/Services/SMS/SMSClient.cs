using BaiduBce;
using BaiduBce.Internal;
using BaiduBce.Model;
using BaiduBce.Services.SMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaiduBce.Services.SMS
{
    public class SMSClient : BceClientBase
    {
        private const string serviceEndpointFormat = "{0}://smsv3.{1}.bcebos.com";

        public SMSClient(BceClientConfiguration config)
          : base(config, serviceEndpointFormat)
        {
        }

        public SendSMSResponse SendSMS(SendSMSRequest request)
        {
            CheckNotNull(request, "request should NOT be null.");

            var internalRequest = this.CreateInternalRequest(BceConstants.HttpMethod.Post, request);

            internalRequest.Content = request.GetConentStream();
            return internalRequest.Config.RetryPolicy.Execute<SendSMSResponse>(attempt =>
            {
                var httpWebResponse = this.httpClient.Execute(internalRequest);
                using (httpWebResponse)
                {
                    return ToObject<SendSMSResponse>(httpWebResponse);
                }
            });
        }

        private InternalRequest CreateInternalRequest(string httpMethod, BceRequestBase request)
        {
            var url = "";
            if (request is SendSMSRequest)
            {
                url = "/api/v3/sendSms";
            }
            return CreateInternalRequest(request.Config, httpMethod, new string[] { url });
        }
    }
}
