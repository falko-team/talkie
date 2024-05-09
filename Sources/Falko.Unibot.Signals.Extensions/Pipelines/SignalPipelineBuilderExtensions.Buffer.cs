using Falko.Unibot.Interceptors;
using Falko.Unibot.Signals;

namespace Falko.Unibot.Pipelines;

public static partial class SignalPipelineBuilderExtensions
{
    public static ISignalInterceptingPipelineBuilder Buffer(this ISignalInterceptingPipelineBuilder builder, TimeSpan delay)
    {
        return builder.Intercept(new BufferSignalInterceptor<Signal>(delay));
    }

    public static ISignalInterceptingPipelineBuilder<T> Buffer<T>(this ISignalInterceptingPipelineBuilder<T> builder, TimeSpan delay)
        where T : Signal
    {
        return builder.Intercept(new BufferSignalInterceptor<T>(delay));
    }
}
