using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
using Taxes.Application.TaxSchedules.Queries.GetTaxScheduleSummary;

namespace Taxes.WebUI.Controllers
{
    [Route("api/taxes/")]
    public class TaxesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxScheduleResponse>>> GetAllAsync([FromQuery] GetTaxesSummaryQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
