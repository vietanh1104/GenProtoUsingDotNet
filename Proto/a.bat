$importPath = "../Proto"
$file = "IDemoInterface.proto"
protoc --proto_path="../Proto" --csharp_out="../" "IDemoInterface.proto"