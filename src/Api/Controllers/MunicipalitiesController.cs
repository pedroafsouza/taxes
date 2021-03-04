using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taxes.Application.Municipalities.Commands.CreateMunicipality;
using Taxes.Application.Municipalities.Commands.UpdateMunicipality;
using Taxes.Application.Municipalities.Queries;
using Taxes.Application.Municipalities.Commands.DeleteMunicipality;

namespace Taxes.Api.Controllers
{
    [Route("api/municipalities")]
    public class MunicipalitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MunicipalityResponse>>> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetAllMunicipalitiesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MunicipalityResponse>>> GetByIdAsync([FromQuery] GetAllMunicipalitiesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<MunicipalityResponse>> Create(CreateMunicipalityCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateMunicipalityCommand command)
        {
            await Mediator.Send(new UpdateMunicipalityCommand { Id = id, Name = command.Name });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMunicipalityCommand { Id = id });

            return NoContent();
        }
    }
}
