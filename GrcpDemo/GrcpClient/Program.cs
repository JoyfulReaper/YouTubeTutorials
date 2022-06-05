using GrcpServer;
using Grpc.Core;
using Grpc.Net.Client;

//var input = new HelloRequest
//{
//    Name = "Tim"
//};

//var channel = GrpcChannel.ForAddress("https://localhost:7099");
//var client = new Greeter.GreeterClient(channel);

//var reply = await client.SayHelloAsync(input);

//Console.WriteLine(reply.Message);



////////////////////////////////////


var channel = GrpcChannel.ForAddress("https://localhost:7099");
var customerClient = new Customer.CustomerClient(channel);

var CustomerRequested = new CustomerLookupModel { UserId = 2 };

var customer = await customerClient.GetCustomerInfoAsync(CustomerRequested);

Console.WriteLine($"{customer.FirstName} {customer.LastName}");

Console.WriteLine();
Console.WriteLine("New Custoemr List");
Console.WriteLine();

using (var call = customerClient.GetNewCustomers(new NewCustomerRequest()))
{
    while (await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;
        Console.WriteLine($"{currentCustomer.FirstName} {currentCustomer.LastName}: {currentCustomer.EmailAddress}");
    }
}


Console.ReadKey();