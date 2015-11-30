using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.CyberSource
{
    public abstract class CyberSource
    {
        public CyberSource()
        {
        }

        protected Dictionary<String, String> data = new Dictionary<string, string>();

        public void add(String key, String value)
        {
            value = (value.Length > 254) ? value.Substring(0, 254) : value;
            data.Add(key, value);
        }

        public String getForPayload()
        {
            string payloadTAG = String.Empty;

            payloadTAG = "";
            foreach (var k in data.Keys)
            {
                payloadTAG += "<" + k.ToUpper() + ">" + data[k] + "</" + k.ToUpper() + ">";
            }
            payloadTAG += "";

            return payloadTAG;
        }
    }
}
