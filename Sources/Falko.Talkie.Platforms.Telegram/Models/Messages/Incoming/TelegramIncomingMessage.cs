using Talkie.Models.Messages.Contents;
using Talkie.Models.Profiles;
using Talkie.Platforms;

namespace Talkie.Models.Messages.Incoming;

public sealed record TelegramIncomingMessage : IIncomingMessage
{
    public required Identifier Identifier { get; init; }

    public required IPlatform Platform { get; init; }

    public required IProfile EnvironmentProfile { get; init; }

    public required IProfile SenderProfile { get; init; }

    public required IProfile ReceiverProfile { get; init; }

    public required DateTime Sent { get; init; }

    public required DateTime Received { get; init; }

    public MessageContent Content { get; init; } = MessageContent.Empty;

    public TelegramIncomingMessage? Reply { get; init; }

    IIncomingMessage? IIncomingMessage.Reply => Reply;

    public TelegramIncomingMessageMutator ToMutator() => new(this);

    IIncomingMessageMutator IIncomingMessage.ToMutator() => ToMutator();
}