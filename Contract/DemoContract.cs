using ProtoBuf.WellKnownTypes;
using System.Runtime.Serialization;

namespace autogenerate_proto.Contract
{
    [DataContract]
    public class DemoContract
    {
        [DataMember(Order = 1, IsRequired = false)]
        public string IdValue1 { get; set; }
        [DataMember(Order = 2, IsRequired = false)]
        public string? IdValue2 { get; set; }
        [DataMember(Order = 3, IsRequired = false)]
        public int IntValue1 { get; set; }
        [DataMember(Order = 4, IsRequired = false)]
        public int IntValue2 { get; set; }
        [DataMember(Order = 5, IsRequired = false)]
        public float FloatValue1 { get; set; }
        [DataMember(Order = 6, IsRequired = false)]
        public float? FloatValue2 { get; set; }
        [DataMember(Order = 7, IsRequired = true)]
        public string StringValue1 { get; set; } =  "A";
        [DataMember(Order = 8, IsRequired = false)]
        public string? StringValue2 { get; set; }
        public Timestamp timestamps { get; set; }
        [DataMember(Order = 9, IsRequired = false)]
        public DateTime a { get; set; }
        [DataMember(Order = 10, IsRequired = false)]
        public Guid uuid { get; set; }
    }
    [DataContract]
    public class DemoContract2
    {
        [DataMember(Order = 1, IsRequired = false)]
        public string IdValue { get; set; }
        [DataMember(Order = 2, IsRequired = false)]
        public Timestamp timestamps { get; set; }
        [DataMember(Order = 3, IsRequired = false)]
        public DateTime a { get; set; }
        [DataMember(Order = 4, IsRequired = false)]
        public Guid uuid { get; set; }
    }
}
