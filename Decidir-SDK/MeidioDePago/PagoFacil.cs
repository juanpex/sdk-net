using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.MeidioDePago
{
    public class PagoFacil:MedioDePago
    {
        public PagoFacil(String MEDIODEPAGO, String RECARGO, String FECHAVTO, String FECHAVTO2)
            : base(MEDIODEPAGO)
        {
            data.Add("RECARGO", RECARGO);
            data.Add("FECHAVTO", FECHAVTO);
            data.Add("FECHAVTO2", FECHAVTO2);
        }
        public void setFECHAVTO(String FECHAVTO)
        {
            data.Add("FECHAVTO", FECHAVTO);
        }
        public void setFECHAVTO2(String FECHAVTO2)
        {
            data.Add("FECHAVTO", FECHAVTO2);
        }
        public void setRECARGO(String RECARGO)
        {
            data.Add("RECARGO", RECARGO);
        }
    }
}
