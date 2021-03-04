using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
using Taxes.Domain.Entities;
using Taxes.Application.TaxSchedules.Commands.CreateTaxSchedule;
using Taxes.Application.TaxSchedules.Commands.UpdateTaxSchedule;
using Taxes.Application.TaxSchedules.Commands.DeleteTaxSchedule;

namespace Taxes.Api.Controllers
{
    [Route("api/municipalities/{MunicipalityId:int}/taxschedules")]
    public class TaxSchedulesController : ApiControllerBase
    {
        [FromRoute]
        public Int32 MunicipalityId { get; set; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxScheduleResponse>>> GetAllAsync()
        {
            return Ok(await Mediator.Send(new GetTaxSchedulesQuery { MunicipalityId = MunicipalityId }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTaxScheduleCommand command)
        {
            if (MunicipalityId != command.MunicipalityId)
            {
                return BadRequest();
            }

            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateTaxScheduleCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTaxScheduleCommand { Id = id });

            return NoContent();
        }
    }
}
