/*using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Reflection;
using Google.Protobuf.Reflection;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ProtoGenerationController : ControllerBase
{
    [HttpPost("/genproto")]
    public async Task<IActionResult> GenProto(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var content = memoryStream.ToArray();

            var schema = await GenerateProtoSchemaAsync(content);

            return File(content, "application/x-protobuf", $"{file.FileName}.proto");
        }
    }

    private async Task<string> GenerateProtoSchemaAsync(byte[] content)
    {
        var serviceDefinitions = ExtractServiceDefinitions(content);
        if (serviceDefinitions == null || serviceDefinitions.Count == 0)
        {
            return string.Empty;
        }

        var builder = new StringBuilder();
        foreach (var serviceDefinition in serviceDefinitions)
        {
            AppendServiceProto(builder, serviceDefinition);
        }

        return builder.ToString();
    }

    private List<Google.Protobuf.Reflection.ServiceDescriptor> ExtractServiceDefinitions(byte[] content)
    {
        var services = new List<Google.Protobuf.Reflection.ServiceDescriptor>();
        var protoService = new ProtoReflectionService(content);
        var fileDescriptors = protoService.GetSchema();
        foreach (var fileDescriptor in fileDescriptors)
        {
            foreach (var service in fileDescriptor.Services)
            {
                services.Add(service);
            }
        }
        return services;
    }

    private void AppendServiceProto(StringBuilder builder, ServiceDescriptor serviceDescriptor)
    {
        builder.AppendLine($"service {serviceDescriptor.Name} {{");
        foreach (var method in serviceDescriptor.Methods)
        {
            builder.AppendLine($"  rpc {method.Name}({method.InputType.Name}) returns ({method.OutputType.Name});");
        }
        builder.AppendLine("}");
        builder.AppendLine();
    }
}
*/