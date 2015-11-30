﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData
{
    public class GetAuthorizeAnswerData
    {

        String security = "";
        String session = "";
        String merchant = "";
        String requestKey = "";
        String answerKey = "";

        public GetAuthorizeAnswerData()
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
        public String getRequestKey()
        {
            return requestKey;
        }
        public void setRequestKey(String requestKey)
        {
            this.requestKey = requestKey;
        }
        public String getAnswerKey()
        {
            return answerKey;
        }
        public void setAnswerKey(String answerKey)
        {
            this.answerKey = answerKey;
        }

    }
}
