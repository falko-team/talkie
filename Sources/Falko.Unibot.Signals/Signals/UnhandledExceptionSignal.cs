namespace Falko.Unibot.Signals;

public sealed record UnhandledExceptionSignal(object? Sender, Exception Exception) : Signal;
