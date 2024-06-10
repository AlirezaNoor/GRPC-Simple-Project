# gRPC in ASP.NET Core

This project demonstrates how to implement gRPC services in ASP.NET Core.

## Table of Contents

- [Introduction](#introduction)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Project](#running-the-project)
- [Project Structure](#project-structure)
- [Protobuf Definition](#protobuf-definition)
- [Implementing the Service](#implementing-the-service)
- [Writing the Client](#writing-the-client)
- [Testing the Service](#testing-the-service)
- [Contributing](#contributing)
- [License](#license)

## Introduction

gRPC is a high-performance RPC framework developed by Google. It uses HTTP/2 for transport, Protocol Buffers as the interface description language, and provides features such as authentication, load balancing, and more.

This project demonstrates a basic gRPC service implemented in ASP.NET Core, including the server and client setup.

## Prerequisites

- [.NET SDK 3.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio or Visual Studio Code](https://visualstudio.microsoft.com/)

## Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/GrpcGreeter.git
    cd GrpcGreeter
    ```

2. Build the project:

    ```bash
    dotnet build
    ```

## Running the Project

1. Run the gRPC server:

    ```bash
    dotnet run
    ```

2. Open another terminal or command prompt and navigate to the client project directory:

    ```bash
    cd GrpcGreeterClient
    dotnet run
    ```

## Project Structure

- **Protos:** Contains the Protobuf definitions.
- **Services:** Contains the implementation of gRPC services.
- **Program.cs and Startup.cs:** Configuration and setup for ASP.NET Core.

## Protobuf Definition

The `greet.proto` file defines the gRPC service and messages:

```protobuf
syntax = "proto3";

option csharp_namespace = "GrpcGreeter";

package Greet;

message HelloRequest {
  string name = 1;
}

message HelloReply {
  string message = 1;
}

service Greeter {
  rpc SayHello (HelloRequest) returns (HelloReply);
}
```

## Implementing the Service

The GreeterService.cs file in the Services folder implements the gRPC service:



``` public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        return Task.FromResult(new HelloReply
        {
            Message = "Hello " + request.Name
        });
    }
}
```

## Writing the Client

A simple gRPC client can be written to test the service. In a new console project, install the necessary packages and use the following code:


```  using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeter;

class Program
{
    static async Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("https://localhost:5001");
        var client = new Greeter.GreeterClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest { Name = "World" });
        Console.WriteLine("Greeting: " + reply.Message);
    }
}

```




## Testing the Service


Start the gRPC server by running the GrpcGreeter project.
Run the client to send a request to the server and receive a response.


## Contributing


Contributions are welcome! Please fork this repository and submit a pull request for any improvements.

## License

This project is licensed under the MIT License - see the LICENSE file for details.


این فایل README شامل تمام اطلاعات مورد نیاز برای شروع کار با پروژه gRPC در ASP.NET Core است و به کاربران کمک می‌کند تا به راحتی پروژه را نصب، اجرا و تست کنند.


 

