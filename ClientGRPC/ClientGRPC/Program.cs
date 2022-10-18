using ClientGRPC;
using Grpc.Net.Client;

using (var channel = GrpcChannel.ForAddress("https://localhost:7124")) {
    var client = new Product.ProductClient(channel);
    var reply = await client.SayHelloAsync(new HelloRequest {
        Name = "xxx"
    });

    var reply2 = await client.GetAsync( new ProductsRequest() );

    Console.WriteLine(reply.Message);
    foreach (var product in reply2.Product) {
        Console.WriteLine(product);
    }
    Console.ReadKey();
}