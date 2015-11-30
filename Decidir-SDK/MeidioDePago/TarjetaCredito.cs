using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.MeidioDePago
{
    public class TarjetaCredito:MedioDePago
    {
        public TarjetaCredito(String MEDIODEPAGO, String CUOTAS)
            : base(MEDIODEPAGO)
        {
            data.Add("CUOTAS", CUOTAS);
        }
        public TarjetaCredito(String MEDIODEPAGO, String CUOTAS, String BIN)
            : base(MEDIODEPAGO)
        {
            data.Add("CUOTAS", CUOTAS);
            data.Add("BIN", BIN);
        }


        public void setCUOTAS(String CUOTAS)
        {
            data.Add("CUOTAS", CUOTAS);
        }
        public void setBIN(String BIN)
        {
            data.Add("BIN", BIN);
        }
    }
}
