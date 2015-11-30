using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Decidir_SDK.Connector;
using Decidir_SDK.MeidioDePago;
using Decidir_SDK.RequestData;
using Decidir_SDK.RequestData.Execute;

namespace Decidir_SDK
{
    public class Decidir
    {
        private const string Version= "0.0.1";

        private AuthorizeConnector auth;
        private OperationConnector op;

        private const String prd = "https://sps.decidir.com/services/t/1.1/";
        private const String sdb = "https://sandbox.decidir.com/services/t/1.1/";
        public const int production = 0;
        public const int sandbox = 1;
        private string endp = "";

        Dictionary<string, string> headers;

        public Decidir()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateCertificate);
        }

        public Decidir(int endpoint, Dictionary<string, string> headers) : this(endpoint, headers, false) { }

        public Decidir(int endpoint, Dictionary<string, string> headers, bool ssl)
        {
            this.headers = headers;
            switch (endpoint)
            {
                case production:
                    endp = prd;
                    break;
                case sandbox:
                    endp = sdb;
                    break;
                default:
                    endp = sdb;
                    break;
            }
            if (ssl)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateCertificate);
            }

        }




        private bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        //Authorize
        public void initAuthorize()
        {
            auth = new AuthorizeConnector(this.endp, headers);
        }

        public SendAuthorizeRequestResponse sendAuthorizeRequest(SendAuthorizeRequestData sar)
        {
            return auth.sendAuthorizeRequest(sar);
        }
        public GetAuthorizeAnswerResponse getAuthorizeAnswer(GetAuthorizeAnswerData gaa)
        {
            return auth.getAuthorizeAnswer(gaa);
        }
        public ExecuteResponse execute(ExecuteData ex)
        {
            return auth.execute(ex);
        }

        //Operation Service
        public void initOperation()
        {
            op = new OperationConnector(this.endp, headers);
        }
        public object[] get(GetByOperationData data)
        {
            return op.GetByOperationId(data);
        }
       
    }
}
