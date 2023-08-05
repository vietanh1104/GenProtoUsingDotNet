using autogenerate_proto.Contract;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace autogenerate_proto.Interfaces
{
    [ServiceContract]
    public interface IDemoInterface
    {
        [OperationContract]
        Task<DemoContract> GetDemoContractAsync(DemoContract2 request, CallContext context);
    }
}
