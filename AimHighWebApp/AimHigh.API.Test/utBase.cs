using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AimHigh.API.Test
{

    class APIProject : WebApplicationFactory<Program>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            // Sharing the extra set up
            return base.CreateHost(builder);
        }
    }

    [TestClass]
    public class utBase
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}