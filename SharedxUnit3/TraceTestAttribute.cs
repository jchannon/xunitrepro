using System.Diagnostics;
using System.Reflection;
using Xunit.v3;

namespace SharedxUnit3;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class TraceTestAttribute : BeforeAfterTestAttribute
{
    private Activity? _activityForThisTest;

    public override void Before(MethodInfo methodUnderTest, IXunitTest test)
    {
        _activityForThisTest = OpenTelemetryMonitoredFixture.ActivitySource.StartActivity(
            methodUnderTest.Name,
            ActivityKind.Internal,
            new ActivityContext());

        base.Before(methodUnderTest, test);
    }

    public override void After(MethodInfo methodUnderTest, IXunitTest test)
    {
        _activityForThisTest?.Stop();
        base.After(methodUnderTest, test);
    }
}