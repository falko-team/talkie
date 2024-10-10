using Talkie.Localizations;
using Talkie.Models.Identifiers;

namespace Talkie.Models.Profiles;

public sealed record TelegramUserProfile : IUserProfile
{
    public required Identifier Identifier { get; init; }

    public Language Language { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? NickName { get; init; }

    public string? Description { get; init; }
}
