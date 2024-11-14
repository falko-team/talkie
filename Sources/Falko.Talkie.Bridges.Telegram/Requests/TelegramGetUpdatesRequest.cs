namespace Talkie.Bridges.Telegram.Requests;

public sealed class TelegramGetUpdatesRequest
(
    int? offset = null,
    int? limit = null,
    long? timeout = null,
    IReadOnlyList<string>? allowedUpdates = null
)
{
    public readonly long? Offset = offset;

    public readonly long? Limit = limit;

    public readonly long? Timeout = timeout;

    public readonly IReadOnlyList<string>? AllowedUpdates = allowedUpdates;
}