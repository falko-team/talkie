using Falko.Unibot.Collections;
using Falko.Unibot.Concurrent;
using Falko.Unibot.Flows;
using Falko.Unibot.Handlers;
using Falko.Unibot.Interceptors;
using Falko.Unibot.Signals;

namespace Falko.Unibot.Pipelines;

public sealed class SignalPipeline(IEnumerable<ISignalInterceptor> interceptors, IEnumerable<ISignalHandler> handlers)
    : ISignalPipeline
{
    private readonly FrozenSequence<ISignalInterceptor> _interceptors = interceptors.ToFrozenSequence();

    private readonly FrozenSequence<ISignalHandler> _handlers = handlers.ToFrozenSequence();

    private readonly ParallelismMeter _handlersParallelismMeter = new();

    public void Transfer(ISignalFlow flow, Signal signal, CancellationToken cancellationToken = default)
    {
        var currentSignal = signal;

        foreach (var interceptor in _interceptors)
        {
            var result = interceptor.Intercept(currentSignal, cancellationToken);

            if (result.CanContinue is false) return;

            if (result.ReplacedSignal is not null)
            {
                currentSignal = result.ReplacedSignal;
            }
        }

        var context = new SignalContext(flow, signal);

        _handlers.Parallelize(_handlersParallelismMeter)
            .ForEach((handler, scopedCancellationToken) => handler.Handle(context, scopedCancellationToken),
                cancellationToken: cancellationToken);
    }
}
