using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData
{
    public class GetByOperationData
    {
        string IDSITE = "";
        string IDTRANSACTIONSIT = "";

        public GetByOperationData(string IDSITE, string IDTRANSACTIONSIT)
        {
            this.IDSITE = IDSITE;
            this.IDTRANSACTIONSIT = IDTRANSACTIONSIT;

        }

        public string getIDSITE()
        {
            return this.IDSITE;
        }

        public string getIDTRANSACTIONSIT()
        {
            return this.IDTRANSACTIONSIT;
        }
    }
}