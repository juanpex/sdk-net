using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData
{
    public class GetAuthorizeAnswerResponse
    {
        private string statusMessage, authorizationKey, encodingMethod, statusCode, payload;

        public GetAuthorizeAnswerResponse(int sc, string message, string authorizationKey, string encodingMethod, string payload)
        {
            this.statusCode = sc.ToString();
            this.statusMessage = message;
            this.authorizationKey = authorizationKey;
            this.encodingMethod = encodingMethod;
            this.payload = payload;
            
        }

        public string getStatusCode()
        {
            return this.statusCode;
        }
        public string getStatusMessage()
        {
            return this.statusMessage;
        }
        public string getAuthorizationKey()
        {
            return this.authorizationKey;
        }
        public string getEncodingMethod()
        {
            return this.encodingMethod;
        }
        public string getPayload()
        {
            return this.payload;
        }
    }
}
