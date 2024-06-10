using Grpc.Net.Client;
using GrpcClient;

class Program
{
    static async Task Main(string[] args)
    {
        
        /// baryae nadide gerftan ssl
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback = 
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        // ساخت کانال gRPC
        using var channel = GrpcChannel.ForAddress("https://localhost:7166", new GrpcChannelOptions { HttpHandler = httpHandler });
        var client = new Greeter.GreeterClient(channel);

        // ارسال درخواست به سرویس gRPC
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });

        Console.WriteLine("Greeting: " + reply.Message);
    }
}