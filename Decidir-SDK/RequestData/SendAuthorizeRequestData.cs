using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decidir_SDK.Agregadores;
using Decidir_SDK.CyberSource;
using Decidir_SDK.MeidioDePago;
using Decidir_SDK.Split;


namespace Decidir_SDK.RequestData
{
    public class SendAuthorizeRequestData
    {
        String security = "";
        String session = "";
        String merchant = "";
        String url_ok = "";
        String url_error = "";
        String encodingMethod = "";
        
        CyberSourceData data;
        CyberSourceData vertical;

        MedioDePago medioDePago;

        ComerciosAgregadores comercios;

        SplitData split;

        public SendAuthorizeRequestData()
        {
        }


        public String getSecurity()
        {
            return security;
        }
        public void setSecurity(String security)
        {
            this.security = security;
        }
        public String getSession()
        {
            return session;
        }
        public void setSession(String session)
        {
            this.session = session;
        }
        public String getMerchant()
        {
            return merchant;
        }
        public void setMerchant(String merchant)
        {
            this.merchant = merchant;
        }
        public String getUrl_ok()
        {
            return url_ok;
        }
        public void setUrl_ok(String url_ok)
        {
            this.url_ok = url_ok;
        }
        public String getUrl_error()
        {
            return url_error;
        }
        public void setUrl_error(String url_error)
        {
            this.url_error = url_error;
        }
        public String getEncodingMethod()
        {
            return encodingMethod;
        }
        public void setEncodingMethod(String encodingMethod)
        {
            this.encodingMethod = encodingMethod;
        }

        //Fraud Control
        public CyberSourceData getCyberSourceData()
        {
            return data;
        }
        public void setCyberSourceData(CyberSourceData fcd)
        {
            this.data = fcd;
        }
        public CyberSourceData getCyberSourceVertical()
        {
            return vertical;
        }
        public void setCyberSourceVertical(CyberSourceData fcv)
        {
            this.vertical = fcv;
        }

        public void setMedioPago(MedioDePago medioDePago)
        {
            this.medioDePago = medioDePago;
        }

        public void setComerciosAgregadores(ComerciosAgregadores comercio)
        {
            this.comercios = comercio;
        }

        public void setSplit(SplitData split)
        {
            this.split = split;
        }


        public String getPayload()
        {
            String payload = "<Request>";
            payload += "<MERCHANT>" + getMerchant() + "</MERCHANT>";
            payload += "<SECURITY>" + getSecurity() + "</SECURITY>";
            payload += "<SESSION>" + getSession() + "</SESSION>";
            payload += "<URL_OK>" + getUrl_ok() + "</URL_OK>";
            payload += "<URL_ERROR>" + getUrl_error() + "</URL_ERROR>";
            payload += "<ENCODINGMETHOD>" + getEncodingMethod() + "</ENCODINGMETHOD>";

            if (data != null)
            {
                payload += data.getForPayload();
            }

            if (vertical != null)
            {
                payload += vertical.getForPayload();
            }

            if (medioDePago != null)
            {
                payload += medioDePago.getForPayload();
            }
            if (comercios != null)
            {
                payload += comercios.getForPayload();
            }
            if (split != null)
            {
                payload += split.getForPayload();
            }

            payload += "</Request>";
            return payload;
        }

    }
}
