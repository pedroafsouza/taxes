using System;
using System.Collections.Generic;
using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;

namespace Taxes.Application.TaxSchedules.Queries.GetTaxScheduleSummary
{    
    public class TaxesSummaryResponse
    {
        public Int32 MunicipalityId { get; set; }

        public string MunicipalityName { get; set; }

        public IEnumerable<TaxScheduleResponse> TaxSchedules { get; set; }

        public double Result { get; set; }
    }
}
