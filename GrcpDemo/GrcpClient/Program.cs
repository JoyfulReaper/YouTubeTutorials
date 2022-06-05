using GrcpServer;
using Grpc.Net.Client;

var input = new HelloRequest
{
    Name = "Tim"
};

var channel = GrpcChannel.ForAddress("https://localhost:7099");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(input);

Console.WriteLine(reply.Message);

Console.ReadKey();