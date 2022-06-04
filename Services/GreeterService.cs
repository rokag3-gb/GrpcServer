using Grpc.Core;
using GrpcServer;

namespace GrpcServer
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine(
                string.Concat(DateTime.Now
                , ", ", request.Name
                , ", ", context.Host
                , ", ", context.Method
                , ", ", context.Peer
                , ", ", context.Status.StatusCode
                , ", ", context.Status.Detail)
                );

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
                , Info = string.Concat("현재 gRPC 서버의 시각은 ", DateTime.Now, " 입니다.")
            });
        }
    }
}