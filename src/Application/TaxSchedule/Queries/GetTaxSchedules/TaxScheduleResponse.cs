using Taxes.Application.Common.Mappings;
using Taxes.Domain.Entities;
using System;
using Taxes.Domain.Enums;
using AutoMapper;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Taxes.Application.TaxSchedules.Queries.GetTaxSchedules
{
    public class TaxScheduleResponse : IMapFrom<TaxSchedule>
    {
        public int Id { get; set; }

        public Int32 MunicipalityId { get; set; }

        public DateTime StartDate { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TimePeriod TimePeriod { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TaxSchedule, TaxScheduleResponse>()
                .ForMember(opt => opt.MunicipalityId, opt => opt.MapFrom((map) => map.Municipality.Id));
        }
    }
}
