namespace Taxes.Application.Municipalities.Queries
{
    using System;
    using Taxes.Application.Common.Mappings;
    using Taxes.Domain.Entities;

    public class MunicipalityResponse : IMapFrom<Municipality>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
