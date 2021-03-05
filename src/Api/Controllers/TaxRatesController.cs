using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
using Taxes.Application.TaxSchedules.Queries.GetTaxScheduleSummary;

namespace Taxes.Api.Controllers
{
    [Route("api/taxrates/")]
    public class TaxRatesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxScheduleResponse>>> GetAllAsync([FromQuery] GetTaxesSummaryQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
