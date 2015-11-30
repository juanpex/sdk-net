using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Decidir_SDK.RequestData;
using Decidir_SDK.Services_Extensions;

namespace Decidir_SDK.Connector
{
    class OperationConnector
    {

        private OperationsBinding OperationsBinding;
        private OperationsEndpoint OperationsEndpoint;

        private OperationService.OperationPortTypeClient client;

        private Dictionary<string, string> Headers;

        private string endPoint;

        public OperationConnector(string endpoint, Dictionary<string, string> headers)
        {

            this.endPoint = endpoint;
            this.Headers = headers;

            this.OperationsBinding = new OperationsBinding();
            this.OperationsEndpoint = new OperationsEndpoint(endpoint);

        }


        public object[] GetByOperationId(GetByOperationData gbo)
        {
            try
            {
                using (client = new OperationService.OperationPortTypeClient(this.OperationsBinding, this.OperationsEndpoint))
                {
                    HeaderHttpExtension.AddCustomHeaderUserInformation(new OperationContextScope(client.InnerChannel), this.Headers);

                    object[] ret = client.Get(gbo.getIDSITE(), gbo.getIDTRANSACTIONSIT());

                    return ret;
                }
            }
            catch (Exception ex)
            {
                //ExecuteResponse response = new ExecuteResponse(0, ex.Message, "", "", null);
                object[] ret = new object[1];
                ret[0] = ex;
                return ret;
            }
        }




    }
}
