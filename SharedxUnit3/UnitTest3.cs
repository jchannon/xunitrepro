using SharedxUnit3;

//[assembly: AssemblyFixture(typeof(OpenTelemetryMonitoredFixture))]

namespace SharedxUnit3;

[TraceTest]
public class UnitTest3
{
    [Fact]
    public void UnitTest3_Test1()
    {
        Assert.True(true);
    }
}