using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Taxes.Application.Common.Behaviours;
using Taxes.Application.Municipalities.Commands.CreateMunicipality;
using Xunit;

namespace Taxes.Application.UnitTests.Common.Behaviours
{

    public class RequestLoggerTests
    {
        private readonly Mock<ILogger<CreateMunicipalityCommand>> _logger;


        public RequestLoggerTests()
        {
            _logger = new Mock<ILogger<CreateMunicipalityCommand>>();
        }

        [Fact]
        public async Task LoggerShouldHaveBeenCalled()
        {
            var requestLogger = new LoggingBehaviour<CreateMunicipalityCommand>(_logger.Object);
            await requestLogger.Process(new CreateMunicipalityCommand { Name = "Copenhagen" }, new CancellationToken());
        }
    }
}
