using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.MeidioDePago
{
    public class PagoMisCuentas:MedioDePago
    {
        public PagoMisCuentas(String MEDIODEPAGO, String FECHAVTO)
            : base(MEDIODEPAGO)
        {
            data.Add("FECHAVTO", FECHAVTO);
        }

        public void setFECHAVTO(String FECHAVTO)
        {
            data.Add("FECHAVTO", FECHAVTO);
        }
    }
}
