using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.RequestData.Execute
{
    public class ExecuteConfirmacion:ExecuteData
    {
        public ExecuteConfirmacion(String NROCOMERCIO, String NROOPERACION):base()
        {
            data.Add("NROCOMERCIO", NROCOMERCIO);
            data.Add("NROOPERACION", NROOPERACION);
            Operation = "Confirmacion";
        }

    }
}
