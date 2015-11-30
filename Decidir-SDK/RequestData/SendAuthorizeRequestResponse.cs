using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData
{
    public class SendAuthorizeRequestResponse
    {
        private string statusMessage, URL_Request, RequestKey, PublicRequestKey, statusCode;

        public SendAuthorizeRequestResponse(int sc, string message, string url, string requestKey, string publicRequestKey)
        {
            this.statusCode = sc.ToString();
            this.statusMessage = message;
            this.URL_Request = url;
            this.RequestKey = requestKey;
            this.PublicRequestKey = publicRequestKey;
            
        }

        public string getStatusCode()
        {
            return this.statusCode;
        }
        public string getStatusMessage()
        {
            return this.statusMessage;
        }
        public string getURLRequest()
        {
            return this.URL_Request;
        }
        public string getRequestKey()
        {
            return this.RequestKey;
        }
        public string getPublicRequestKey()
        {
            return this.PublicRequestKey;
        }
    }
}
