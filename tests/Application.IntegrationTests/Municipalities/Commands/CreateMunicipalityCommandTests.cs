namespace Taxes.Application.IntegrationTests.Municipalities.Commands
{
    using FluentAssertions;
    using NUnit.Framework;

    using static Testing;
    using Taxes.Application.Common.Exceptions;
    using Taxes.Application.Municipalities.Commands.CreateMunicipality;
    using System.Threading.Tasks;

    public class CreateMunicipalityCommandTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateMunicipalityCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldAcceptMaximunOf200Chars()
        {
            string myString = new string('*', 3000);

            var command = new CreateMunicipalityCommand
            {
                Name = new string('*', 3000)
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }
    }
}
