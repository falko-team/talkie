using Talkie.Signals;

namespace Talkie.Interceptors;

public interface ISignalInterceptor<in T> : ISignalInterceptor where T : Signal
{
    InterceptionResult Intercept(T signal, CancellationToken cancellationToken);
}
