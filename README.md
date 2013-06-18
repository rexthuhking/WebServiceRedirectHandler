WebServiceRedirectHandler
=========================

Simple example that identifies a solution on how to account for HTTP redirects when consuming a web service.

The SampleWebService solution can be deployed to two different IIS applications.

For example: http://localhost/SampleWebService/SampleService.asmx and http://localhost/Sample/SampleService.asmx

In the first location http://localhost/SampleWebService/SampleService.asmx modify the web.config file to add the following section within the <configuration> node.

	<system.webServer>
      <httpRedirect enabled="true" destination="http://localhost/Sample/SampleService.asmx" exactDestination="true" httpResponseStatus="Temporary" />
    </system.webServer>

Once this is done, go ahead and open up the SampleServiceClient console application and step through the code to see how the 302 redirect is handled by the code with the SoapHttpClientProtocolWithRedirect class.