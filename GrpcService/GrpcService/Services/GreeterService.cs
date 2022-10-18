using Grpc.Core;
using GrpcService;

namespace GrpcService.Services {
    public class ProductService : Product.ProductBase{
        private readonly ILogger<ProductService> _logger;
        public ProductService(ILogger<ProductService> logger) {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context) {
            return Task.FromResult(new HelloReply {
                Message = "Hello " + request.Name
            });
        }


        public override Task<ProductsReply> Get(ProductsRequest request, ServerCallContext context) {
            var reply = new ProductsReply();
            reply.Product.AddRange(new List<string>() {
                "item1", "item2", "item3"
            });
            return Task.FromResult(reply);
        }
    }
}