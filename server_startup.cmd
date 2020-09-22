rem Set environment variables
SET CORECLR_ENABLE_PROFILING=1
SET CORECLR_PROFILER={846F5F1C-F9AE-4B07-969E-05C26BC060D8}
SET CORECLR_PROFILER_PATH=%PROGRAMFILES%\Datadog\.NET Tracer\Datadog.Trace.ClrProfiler.Native.dll
SET DD_INTEGRATIONS=%PROGRAMFILES%\Datadog\.NET Tracer\integrations.json
SET DD_DOTNET_TRACER_HOME=%PROGRAMFILES%\Datadog\.NET Tracer
rem Start application
dotnet.exe C:\Users\DDadmin\Desktop\DD_Distributed_Trace\DotNetCore\Synchronus_Server_Socket\Synchronus_Server_Socket\bin\Debug\netcoreapp3.1\Synchronus_Server_Socket.dll