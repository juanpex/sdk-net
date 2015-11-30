using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData.Execute
{
    public class ExecuteAnulacion:ExecuteData
    {
        public ExecuteAnulacion(String NROCOMERCIO, String NROOPERACION, String SECURITY):base()
        {
            data.Add("NROCOMERCIO", NROCOMERCIO);
            data.Add("NROOPERACION", NROOPERACION);
            Operation = "Anulacion";
            Security = SECURITY;
            Merchant = NROCOMERCIO;
        }

    }
}
