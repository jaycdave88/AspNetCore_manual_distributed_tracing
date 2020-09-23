# AspNetCore_manual_distributed_tracing
### About Repo: 

This repo contains .NET Core 3.1 console applications for both Client and Server communication over sockets. The repo uses [Datadog.Trace 1.19.3](https://www.nuget.org/packages/Datadog.Trace) NuGet version to showcase custom distributed tracing. 

### How to use: 

The repo also includes `.cmd` start-up scripts, which will need to be updated to your local path once the .sln is build. Take the path to both the **Synchronous_Client_Socket.dll** & **Synchronus_Server_Socket** and replace within the .cmd scripts.

#### Datadog Flamegraph: 
![flamegraph](https://p-qKFgO2.t2.n0.cdn.getcloudapp.com/items/nOukA4wb/Image%202020-09-22%20at%205.04.14%20PM.png?v=8c9ae94753f02f15cdc748c1f314deac)

Source code from Microsoft examples: 
- [Synchronous Client Socket Example](https://docs.microsoft.com/en-us/dotnet/framework/network-programming/synchronous-client-socket-example)
- [Synchronous Server Socket Example](https://docs.microsoft.com/en-us/dotnet/framework/network-programming/synchronous-server-socket-example) 
