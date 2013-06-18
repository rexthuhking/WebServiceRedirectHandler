using SampleServiceClient.Services;
using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace SampleServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                var sampleServiceClient = new SampleService("http://localhost/SampleWebService/SampleService.asmx");
                Console.WriteLine("Output through ASMX Service Proxy call " + sampleServiceClient.HelloWorld());

                var sampleWcfServiceClient = new SampleServiceClient.ThirdParty.Services.SampleServiceSoapClient();
                sampleWcfServiceClient.Endpoint.Address = new EndpointAddress("http://localhost/SampleWebService/SampleService.asmx");
                Console.WriteLine("Output through WCF Service Reference call " + sampleWcfServiceClient.HelloWorld());
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("Exception encountered. Details are: {0} \n", ex.Message));
            }
            finally
            {
                Console.ReadKey();
            }
        }

        public static bool CheckValidationResult(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }
}
