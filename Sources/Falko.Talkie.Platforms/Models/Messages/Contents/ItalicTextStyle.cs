namespace Talkie.Models.Messages.Contents;

public sealed record ItalicTextStyle(int Offset, int Length) : IMessageTextStyle;