# HelloWorldK8

This C# repository sample application is prepared for Azure Kubernetes deployment to test and scale-out an application that is using WebSockets for the real-time connection between client and server.

The client based on JavaScipt and server on a .NET web application with SignalR.
Infrastructure script is included along with application gateway configuration via Azure Kubernetes YAML manifest. 
There is a need to enable Session Affinity Cookie to have a sticky session for scaled instances in the Kubernetes cluster.

I already discussed the pros and cons of Azure SignalR Service and custom C# solution based on Azure Kubernetes Server, but I will post detailed data as a follow-up article.
