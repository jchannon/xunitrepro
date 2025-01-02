using SharedxUnit3;

namespace App1;

[TraceTest]
public class UnitTest2
{
    // private readonly OpenTelemetryMonitoredFixture fixture;
    //
    // public UnitTest2(OpenTelemetryMonitoredFixture fixture)
    // {
    //     this.fixture = fixture;
    // }
    
    [Fact]
    public void UnitTest2_Test1()
    {
        Assert.True(true);
    }
}