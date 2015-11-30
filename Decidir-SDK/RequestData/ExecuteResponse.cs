using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData
{
    public class ExecuteResponse
    {
        private string statusCode="";
        private string statusMessage="";
        private string authorizationKey="";
        private string encoding = "";
        private object payload;

        public ExecuteResponse(int statusCode, string statusMessage, string authorizationKey, string encoding, object payload)
        {
            this.statusCode = statusCode.ToString();
            this.statusMessage = statusMessage;
            this.authorizationKey = authorizationKey;
            this.encoding = encoding;
            this.payload = payload;
        }

        public string getStatusCode()
        {
            return statusCode;
        }
        public string getStatusMessage()
        {
            return statusMessage;
        }
        public string getAuthorizationKey()
        {
            return authorizationKey;
        }
        public string getEncoding()
        {
            return encoding;
        }
        public string getPayloadString()
        {
            return payload.ToString();
        }
        public Object getPayload()
        {
            return payload;
        }
    }
}
