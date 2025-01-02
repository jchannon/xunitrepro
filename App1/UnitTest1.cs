using SharedxUnit3;

[assembly: AssemblyFixture(typeof(OpenTelemetryMonitoredFixture))]

namespace App1;

[TraceTest]
public class UnitTest1
{
    [Fact]
    public void UnitTest1_Test1()
    {
        Assert.True(true);
    }
}