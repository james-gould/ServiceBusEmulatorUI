using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.Azure;

namespace AzureServiceBusEmulatorUI.Aspire.Hosting;

public static class AzureServiceBusEmulatorUIExtensions
{
    public static IResourceBuilder<AzureServiceBusResource> AddUI(this IResourceBuilder<AzureServiceBusResource> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        if (builder.ApplicationBuilder.ExecutionContext.IsPublishMode)
            return builder;

        var resource = builder.ApplicationBuilder
            .CreateResourceBuilder(new AzureServiceBusEmulatorUIResource(builder.Resource));

        return builder;
    }

    private class AzureServiceBusEmulatorUIResource(AzureServiceBusResource resource) : ContainerResource(resource.Name)
    {
        public override ResourceAnnotationCollection Annotations => resource.Annotations;
    }
}
