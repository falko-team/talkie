namespace Talkie.Models.Messages.Contents;

public sealed record MonospaceTextStyle(int Offset, int Length) : IMessageTextStyle;