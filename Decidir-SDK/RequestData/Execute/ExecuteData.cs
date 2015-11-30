using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData.Execute
{
    public abstract class ExecuteData
    {
        protected String EncodingMethod = "";
        protected String Merchant = "";
        protected String Security = "";
        protected String Session = "";

        protected String Operation = "";

        protected Dictionary<String, String> data = new Dictionary<String, String>();

        public ExecuteData()
        {
        }

        public String getEncodingMethod()
        {
            return EncodingMethod;
        }
        public void setEncodingMethod(String encoding)
        {
            EncodingMethod = encoding;
        }

        public String getMerchant()
        {
            return Merchant;
        }
        public void setMerchant(String merchant)
        {
            Merchant = merchant;
        }

        public String getOperation()
        {
            return Operation;
        }
        public void setOperation(String operation)
        {
            Operation = operation;
        }

        public String getSecurity()
        {
            return Security;
        }
        public void setSecurity(String security)
        {
            Security = security;
        }

        public String getSession()
        {
            return Session;
        }
        public void setSession(String session)
        {
            Session = session;
        }


        public String getPayload() {
            String payloadTAG = "<Request>";

        foreach (var k in data.Keys)
        {
            payloadTAG += "<" + k.ToUpper() + ">" + data[k] + "</" + k.ToUpper() + ">";
        }

        payloadTAG += "</Request>";
        return payloadTAG;
	}

    }
}
