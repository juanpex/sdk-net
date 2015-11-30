using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decidir_SDK
{
    using System.ServiceModel;

    public class AuthorizeBinding : BasicHttpBinding
    {
        public AuthorizeBinding()
            : base()
        {
            this.Security.Mode = BasicHttpSecurityMode.Transport;
        }
    }

    public class AuthorizeEndpoint : EndpointAddress
    {
        public AuthorizeEndpoint(string uri)
            : base(uri + @"/Authorize.AuthorizeHttpsSoap12Endpoint")
        {
        }
    }
}
