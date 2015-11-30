using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.Agregadores
{
    public class ComerciosAgregadores
    {
        public const String aindicador="aindicador";
	    public const String adocumento="adocumento";
	    public const String afactpagar="afactpagar";
	    public const String afactdevol="afactdevol";
	    public const String anombrecom="anombrecom";
	    public const String adomiciliocomercio="adomiciliocomercio";
	    public const String anropuerta="anropuerta";
	    public const String acodpostal="acodpostal";
	    public const String arubro="arubro";
	    public const String acodcanal="acodcanal";
        public const String acodgeografico = "acodgeografico";

        private Dictionary<String, String> data = new Dictionary<string, string>();

        public ComerciosAgregadores()
        {
        }

        public void add(String key, String value)
        {
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
