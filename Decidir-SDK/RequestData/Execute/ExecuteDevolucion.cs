using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData.Execute
{
    public class ExecuteDevolucion:ExecuteData
    {
        /*Devolucion Total*/
        public ExecuteDevolucion(String NROCOMERCIO, String NROOPERACION, String SECURITY):base()
        {
            data.Add("NROCOMERCIO", NROCOMERCIO);
            data.Add("NROOPERACION", NROOPERACION);
            Operation = "Devolucion";
            Security = SECURITY;
            Merchant = NROCOMERCIO;
        }
        /*Devolucion Parcial
         * */
        public ExecuteDevolucion(String NROCOMERCIO, String NROOPERACION, String MONTO, String SECURITY):base()
        {
            data.Add("NROCOMERCIO", NROCOMERCIO);
            data.Add("NROOPERACION", NROOPERACION);
            data.Add("MONTO", MONTO);
            Operation = "Devolucion";
            Security = SECURITY;
            Merchant = NROCOMERCIO;
        }
	
    }
}
