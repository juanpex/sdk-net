using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Decidir_SDK.RequestData;
using Decidir_SDK.RequestData.Execute;
using Decidir_SDK.Services_Extensions;

namespace Decidir_SDK.Connector
{
    class AuthorizeConnector
    {

        private AuthorizeBinding AuthorizeBinding;
        private AuthorizeEndpoint AuthorizeEndpoint;

        private AuthorizeService.AuthorizePortTypeClient client;

        private Dictionary<string, string> Headers;

        private string endPoint;

        public AuthorizeConnector(string endpoint, Dictionary<string, string> headers)
        {

            this.endPoint = endpoint;
            this.Headers = headers;

            this.AuthorizeBinding = new AuthorizeBinding();
            this.AuthorizeEndpoint = new AuthorizeEndpoint(endPoint);
            

        }

        public SendAuthorizeRequestResponse sendAuthorizeRequest(SendAuthorizeRequestData sar)
        {
            try
            {
                using (client = new AuthorizeService.AuthorizePortTypeClient(this.AuthorizeBinding, this.AuthorizeEndpoint))
                {
                    HeaderHttpExtension.AddCustomHeaderUserInformation(new OperationContextScope(client.InnerChannel), this.Headers);

                    string statusMessage, URL_Request, RequestKey, PublicRequestKey;

                    var statusCode = client.SendAuthorizeRequest(sar.getSecurity(),
                                                                 sar.getSession(),
                                                                 sar.getMerchant(),
                                                                 sar.getUrl_ok(),
                                                                 sar.getUrl_error(),
                                                                 sar.getEncodingMethod(),
                                                                 sar.getPayload(),
                                                                 out statusMessage,
                                                                 out URL_Request,
                                                                 out RequestKey,
                                                                 out PublicRequestKey);

                    SendAuthorizeRequestResponse response = new SendAuthorizeRequestResponse(statusCode, statusMessage, URL_Request, RequestKey, PublicRequestKey);
                    return response;
                }
            }
            catch (Exception ex)
            {
                SendAuthorizeRequestResponse response = new SendAuthorizeRequestResponse(0, ex.Message, "", "", "");
                return response;
            }
        }



        public GetAuthorizeAnswerResponse getAuthorizeAnswer(GetAuthorizeAnswerData gaa)
        {
            try
            {
                using (client = new AuthorizeService.AuthorizePortTypeClient(this.AuthorizeBinding, this.AuthorizeEndpoint))
                {
                    Console.WriteLine(client.Endpoint.Address);
                    HeaderHttpExtension.AddCustomHeaderUserInformation(new OperationContextScope(client.InnerChannel), this.Headers);

                    string statusMessage, authorizationKey, encodingMethod;
                    object payload;

                    var statusCode = client.GetAuthorizeAnswer(
                        gaa.getSecurity(),
                        gaa.getSession(),
                        gaa.getMerchant(),
                        gaa.getRequestKey(),
                        gaa.getAnswerKey(),
                        out statusMessage,
                        out authorizationKey,
                        out encodingMethod,
                        out payload);

                    GetAuthorizeAnswerResponse response = new GetAuthorizeAnswerResponse(statusCode, statusMessage, authorizationKey, encodingMethod, payload.ToString());
                    return response;
                }
            }
            catch (Exception ex)
            {
                GetAuthorizeAnswerResponse response = new GetAuthorizeAnswerResponse(0, ex.Message, "", "", "");
                return response;
            }
        }

        public ExecuteResponse execute(ExecuteData exe)
        {
            try
            {
                using (client = new AuthorizeService.AuthorizePortTypeClient(this.AuthorizeBinding, this.AuthorizeEndpoint))
                {
                    HeaderHttpExtension.AddCustomHeaderUserInformation(new OperationContextScope(client.InnerChannel), this.Headers);

                    string statusMessage, authorizationKey;
                    string enc = exe.getEncodingMethod();
                    Object pay = exe.getPayload();

                    var statusCode = client.Execute(
                        exe.getSecurity(), 
                        exe.getSession(), 
                        exe.getMerchant(), 
                        exe.getOperation(), 
                        ref enc, 
                        ref pay, 
                        out statusMessage, 
                        out authorizationKey);
                    
                    ExecuteResponse response = new ExecuteResponse(statusCode, statusMessage, authorizationKey, enc, pay);
                    return response;
                }
            }
            catch (Exception ex)
            {
                ExecuteResponse response = new ExecuteResponse(0, ex.Message, "", "", null);
                return response;
            }
        }
    }
}
