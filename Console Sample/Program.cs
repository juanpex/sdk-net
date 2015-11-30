using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Decidir_SDK;
using Decidir_SDK.RequestData;
using Decidir_SDK.RequestData.Execute;
using Decidir_SDK.MeidioDePago;


namespace Console_Sample
{
    class Program
    {
        static Decidir decidir;

        static String MERCHANT = "22067736";
        static String ENCODINGMETHOD = "XML";
        static String SECURITY = "RV82RVHO5T0O5CZUUTX2FLHU";

        //Authentification and Endpoint
        static string authorization = "PRISMA f3d8b72c94ab4a06be2ef7c95490f7d3";
        static int endpoint = Decidir.sandbox;//Developer sandbox
        //static int endpoint = Decidir.production; //produccion


        static void Main(string[] args)
        {
            //Init Decidir       
            decidir = new Decidir(endpoint, getHeaders());

            authorizeSample();
            operationSample();

        }

        public static Dictionary<string, string> getHeaders()
        {
            var headers = new Dictionary<String, String>();
            headers.Add("Authorization", authorization);
            //Add here aditional HTTP Headers
            return headers;
        }


        public static void authorizeSample()
        {
            try
            {
                decidir.initAuthorize();

                //SendAuthorizeRequest
                SendAuthorizeRequestData sar = initSendAuthorizeRequestData();
                SendAuthorizeRequestResponse sarResponse = decidir.sendAuthorizeRequest(sar);
                printSendAuthorizeRequestResponse(sarResponse);

                //GetAuthorizeAnswer
                GetAuthorizeAnswerData gaa = initGetAuthorizeAnswerData();
                GetAuthorizeAnswerResponse gaaResponse = decidir.getAuthorizeAnswer(gaa);
                printGetAuthorizeAnswerResponse(gaaResponse);

                //Execute
                ExecuteResponse exResponse = decidir.execute(initExecuteData());
                printExecuteResponse(exResponse);

            }
            catch (Exception ex)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(ex.Message);
            }

        }

        
        public static SendAuthorizeRequestData initSendAuthorizeRequestData()
        {

            SendAuthorizeRequestData sar = new SendAuthorizeRequestData();

            sar.setEncodingMethod(ENCODINGMETHOD);
            sar.setMerchant(MERCHANT);
            sar.setSecurity(SECURITY);
            sar.setUrl_error("http://someurl.com/error/");
            sar.setUrl_ok("http://someurl.com/ok/");

            MedioDePago medioDePago = new TarjetaCredito("1", "6");

            sar.setMedioPago(medioDePago);

            return sar;
        }
        public static GetAuthorizeAnswerData initGetAuthorizeAnswerData()
        {
            GetAuthorizeAnswerData gaa = new GetAuthorizeAnswerData();
            gaa.setMerchant(MERCHANT);
            gaa.setSecurity(SECURITY);
            gaa.setRequestKey("cdf96aaf-dd1c-195b-eeee-130a3df96110");
            gaa.setAnswerKey("77215fe6-f9d5-f1c2-372b-c0065e0c4429");
            return gaa;
        }
        public static ExecuteData initExecuteData()
        {
            ExecuteData ex = new ExecuteAnulacion(MERCHANT, "123456", SECURITY);//Anulacion
            //ExecuteData ex = new ExecuteDevolucion(MERCHANT, "123456", "10.00", SECURITY);//Devolucion Parcial
            //ExecuteData ex = new ExecuteDevolucion(MERCHANT, "123456", SECURITY);//Devolucion Total

            return ex;
        }



        public static void operationSample()
        {
            try
            {
                decidir.initOperation();

                object[] ops = decidir.get(initGetData());
                printOperations(ops);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static GetByOperationData initGetData()
        {
            GetByOperationData data = new GetByOperationData(MERCHANT, "123456");
            return data;
        }
        


        //Sample Print Methods
        public static void printSendAuthorizeRequestResponse(SendAuthorizeRequestResponse sarResponse)
        {
	        Console.WriteLine("Status Code: " + sarResponse.getStatusCode());
	        Console.WriteLine("StatusMessage: " + sarResponse.getStatusMessage());
	        Console.WriteLine("PublicRequestKey: " + sarResponse.getPublicRequestKey());
	        Console.WriteLine("RequestKey: " + sarResponse.getRequestKey());
            Console.WriteLine("URLRequest: " + sarResponse.getURLRequest());
	    }
        public static void printGetAuthorizeAnswerResponse(GetAuthorizeAnswerResponse gaaResponse)
        {
		    Console.WriteLine("Status Code: " + gaaResponse.getStatusCode());
		    Console.WriteLine("AuthorizationKey: " + gaaResponse.getAuthorizationKey());
		    Console.WriteLine("EncodingMethod: " + gaaResponse.getEncodingMethod());
		    Console.WriteLine("StatusMessage: " + gaaResponse.getStatusMessage());
            Console.WriteLine("Payload: " + gaaResponse.getPayload());
	    }
        public static void printExecuteResponse(ExecuteResponse exResponse) {
            Console.WriteLine("Status Code: " + exResponse.getStatusCode());
		    Console.WriteLine("StatusMessage: " + exResponse.getStatusMessage());
		    Console.WriteLine("AuthorizationKey: " + exResponse.getAuthorizationKey());
		    Console.WriteLine("EncodingMethod: " + exResponse.getEncoding());
            Console.WriteLine("Payload: " + exResponse.getPayload());		
	    }
        public static void printOperations(object[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    Console.WriteLine(data[i].ToString());
                }
                else
                {
                    Console.WriteLine("value at " + i + "was null");
                }
            }
        }

	    

	
    }
}
