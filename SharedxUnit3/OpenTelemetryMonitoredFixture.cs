using System.Diagnostics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using SharedxUnit3;

[assembly: AssemblyFixture(typeof(OpenTelemetryMonitoredFixture))]

namespace SharedxUnit3;

public class OpenTelemetryMonitoredFixture : IDisposable
{
    private const string TracerName = "helix-tests";

    public static readonly ActivitySource ActivitySource = new(TracerName);

    private static readonly TracerProvider? _tracerProvider;

    static OpenTelemetryMonitoredFixture()
    {
        _tracerProvider = global::OpenTelemetry.Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("helix-tests"))
            .AddSource(TracerName)
            .AddOtlpExporter(ex => { ex.Endpoint = new Uri("http://localhost:4317"); })
            .Build();
    }

    public void Dispose()
    {
        _tracerProvider?.ForceFlush();
        _tracerProvider?.Dispose();
    }
}