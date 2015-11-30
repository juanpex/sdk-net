using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.Split
{
    public abstract class SplitData
    {

        protected Dictionary<String, String> data = new Dictionary<String, String>();

        public SplitData()
        {
        }

        public void add(String key, String value)
        {
            data.Add(key, value);
        }

        public String getForPayload() {
            string payloadTAG = String.Empty;
            
            payloadTAG = "";
            
            foreach (var k in data.Keys)
            {
                payloadTAG += "<" + k.ToUpper() + ">" + data[k] + "</" + k.ToUpper() + ">";
            }
            
            return payloadTAG;
	}




    }
}
