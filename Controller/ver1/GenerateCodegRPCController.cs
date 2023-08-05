
using autogenerate_proto.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Reflection;
using ProtoBuf.Meta;
using System.ComponentModel;

namespace autogenerate_proto.Controller.ver1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    [Description]
    public class GenerateCodegRPCController : ControllerBase
    {
        private readonly ILogger<GenerateCodegRPCController> _logger;
        private readonly IConfiguration _config;

        public GenerateCodegRPCController(ILogger<GenerateCodegRPCController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
        }
        /// <summary>
        /// Gen file .proto
        /// </summary>
        /// <param name="optional">
        ///     1 : download and save ; 2 : save ; default : download
        /// </param>
        /// <returns></returns>
        [MapToApiVersion("1.0")]
        [HttpPost("/genproto")]
        public async Task<IActionResult> GenProto(int optional)
        {
            var generator = new SchemaGenerator
            {
                ProtoSyntax = ProtoSyntax.Proto3
            };
            // replace name of interface with your interface that you need to generate file .proto
            var nameOfInterface = nameof(IDemoInterface);
            var outputPath = string.Format(_config.GetValue<string>("ProtoFile"), nameOfInterface);
            var schema = generator.GetSchema<IDemoInterface>(); // there is also a non-generic overload that takes Type

            switch (optional)
            {
                case 1:
                    {
                        using (var stream = System.IO.File.OpenWrite(outputPath))
                        {
                            using (var writer = new System.IO.StreamWriter(stream))
                                await writer.WriteAsync(schema);

                        }
                        using (var stream = new MemoryStream())
                        {
                            using (var writer = new System.IO.StreamWriter(stream))
                                await writer.WriteAsync(schema);
                            var content = stream.ToArray();
                            return File(
                                content,
                                "application/x-protobuf",
                                $"{nameOfInterface}.proto");
                        }
                    };
                    break;
                case 2:
                    {
                        using (var stream = System.IO.File.OpenWrite(outputPath))
                        {
                            using (var writer = new System.IO.StreamWriter(stream))
                                await writer.WriteAsync(schema);

                        }
                        return Ok();
                    };
                    break;
                default:
                    {
                        using (var stream = new MemoryStream())
                        {
                            using (var writer = new System.IO.StreamWriter(stream))
                                await writer.WriteAsync(schema);
                            var content = stream.ToArray();
                            return File(
                                content,
                                "application/x-protobuf",
                                $"{nameOfInterface}.proto");
                        }
                    }
            }
        }
    }
}
