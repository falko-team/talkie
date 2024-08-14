using Talkie.Models.Messages;

namespace Talkie.Controllers;

public static partial class OutgoingMessageControllerExtensions
{
    public static Task PublishMessageAsync(this IOutgoingMessageController controller, IOutgoingMessageMutator mutator,
        MessagePublishingFeatures features = default,
        CancellationToken cancellationToken = default)
    {
        return controller.PublishMessageAsync(mutator.Mutate(), features, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, IOutgoingMessageMutator mutator,
        CancellationToken cancellationToken)
    {
        return controller.PublishMessageAsync(mutator, default, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, IOutgoingMessageBuilder builder,
        MessagePublishingFeatures features = default,
        CancellationToken cancellationToken = default)
    {
        return controller.PublishMessageAsync(builder.Build(), features, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, IOutgoingMessageBuilder builder,
        CancellationToken cancellationToken)
    {
        return controller.PublishMessageAsync(builder, default, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, Func<IOutgoingMessageBuilder, IOutgoingMessageBuilder> builderFactory,
        MessagePublishingFeatures features = default,
        CancellationToken cancellationToken = default)
    {
        return controller.PublishMessageAsync(builderFactory(new OutgoingMessageBuilder()).Build(), features, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, Func<IOutgoingMessageBuilder, IOutgoingMessageBuilder> builderFactory,
        CancellationToken cancellationToken)
    {
        return controller.PublishMessageAsync(builderFactory, default, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, string text,
        MessagePublishingFeatures features = default,
        CancellationToken cancellationToken = default)
    {
        return controller.PublishMessageAsync(message => message.AddText(text), features, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, string text,
        CancellationToken cancellationToken)
    {
        return controller.PublishMessageAsync(text, default, cancellationToken);
    }

    public static Task PublishMessageAsync(this IOutgoingMessageController controller, IOutgoingMessage message,
        CancellationToken cancellationToken)
    {
        return controller.PublishMessageAsync(message, default, cancellationToken);
    }
}
