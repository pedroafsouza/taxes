namespace Taxes.Application.IntegrationTests.Municipalities.Commands
{
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;
    using Taxes.Application.Common.Exceptions;
    using Taxes.Application.Municipalities.Commands.CreateMunicipality;
    using Taxes.Application.Municipalities.Commands.DeleteMunicipality;
    using Taxes.Domain.Entities;
    using static Testing;

    public class DeleteMunicipalityCommandTests
    {
        [Test]
        public void ShouldRequireValideMunicipality()
        {
            var command = new DeleteMunicipalityCommand { Id = 275 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var municipality = await SendAsync(new CreateMunicipalityCommand
            {
                Name = "Randers"
            });

            await SendAsync(new DeleteMunicipalityCommand
            {
                Id = municipality.Id
            });
            
            var list = await FindAsync<Municipality>(municipality.Id);

            list.Should().BeNull();
        }
    }
}
