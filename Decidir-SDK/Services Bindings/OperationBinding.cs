using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK
{
    using System.ServiceModel;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class OperationsBinding : BasicHttpBinding
    {
        public OperationsBinding()
            : base()
        {
            this.Security.Mode = BasicHttpSecurityMode.Transport;
        }
    }

    public class OperationsEndpoint : EndpointAddress
    {
        public OperationsEndpoint(string uri)
            : base(uri + @"/services/Operations")
        {
        }
    }
}