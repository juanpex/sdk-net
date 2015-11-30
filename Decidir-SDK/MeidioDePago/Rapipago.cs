using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK.MeidioDePago
{
    public class Rapipago:MedioDePago
    {
        public Rapipago(String MEDIODEPAGO, String CANTDIASFECHAVENC, String CANTDIASPAGO, String RECARGO, String FECHAVTO, String CLIENTE)
            : base(MEDIODEPAGO)
        {

            data.Add("CANTDIASFECHAVENC", CANTDIASFECHAVENC);
            data.Add("CANTDIASPAGO", CANTDIASPAGO);
            data.Add("RECARGO", RECARGO);
            data.Add("FECHAVTO", FECHAVTO);
            data.Add("CLIENTE", CLIENTE);
        }

        public void setCANTDIASFECHAVENC(String CANTDIASFECHAVENC)
        {
            data.Add("CANTDIASFECHAVENC", CANTDIASFECHAVENC);
        }
        public void setCANTDIASPAGO(String CANTDIASPAGO)
        {
            data.Add("CANTDIASPAGO", CANTDIASPAGO);
        }
        public void setRECARGO(String RECARGO)
        {
            data.Add("RECARGO", RECARGO);
        }
        public void setFECHAVTO(String FECHAVTO)
        {
            data.Add("FECHAVTO", FECHAVTO);
        }
        public void setCLIENTE(String CLIENTE)
        {
            data.Add("CLIENTE", CLIENTE);
        }
    }
}
