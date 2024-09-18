using Talkie.Handlers;
using Talkie.Pipelines.Intercepting;
using Talkie.Sequences;

namespace Talkie.Pipelines.Handling;

public abstract class ElementarySignalHandlingPipelineBuilder : IReadOnlySignalHandlingPipelineBuilder
{
    private readonly Sequence<ISignalHandler> _handlers = new();

    protected ElementarySignalHandlingPipelineBuilder() { }

    protected ElementarySignalHandlingPipelineBuilder(ISignalInterceptingPipeline? interceptingPipeline)
    {
        ArgumentNullException.ThrowIfNull(interceptingPipeline);

        Intercepting = interceptingPipeline;
    }

    public ISignalInterceptingPipeline? Intercepting { get; }

    public IEnumerable<ISignalHandler> Handlers => _handlers;

    public ISignalHandlingPipeline Build() => SignalHandlingPipelineFactory.Create(Handlers, Intercepting);

    protected void AddHandler(ISignalHandler handler) => _handlers.Add(handler);
}
