namespace Taxes.Application.Municipalities.Queries
{
    using Taxes.Application.Common.Mappings;
    using Taxes.Domain.Entities;

    public class MunicipalityResponse : IMapFrom<Municipality>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
