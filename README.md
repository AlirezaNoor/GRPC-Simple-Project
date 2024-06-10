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
