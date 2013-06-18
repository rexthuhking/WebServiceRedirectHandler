using SampleServiceClient.Services;
using System;

namespace SampleServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sampleServiceClient = new SampleService("http://localhost/SampleWebService/SampleService.asmx");
                Console.WriteLine(sampleServiceClient.HelloWorld());
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
    }
}
