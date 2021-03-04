using System.Threading.Tasks;

namespace Taxes.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
