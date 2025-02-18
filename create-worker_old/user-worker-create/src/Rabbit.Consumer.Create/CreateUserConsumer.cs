﻿using CreateEntitys;
using CreateInterface.Gateway.Queue;
using MassTransit;
using Presenters;

namespace Rabbit.Consumer.Create;

public class CreateUserConsumer(ICreateUserGateway createUserGateway) : IConsumer<UserDto>
{
    private readonly ICreateUserGateway _createUserGateway = createUserGateway;

    public async Task Consume(ConsumeContext<UserDto> context)
    {
        var message = context.Message;
        Console.WriteLine($"Received message: {message}");
        var result = await _createUserGateway.CreateAsync(message);
    }
}
