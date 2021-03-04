namespace Taxes.Application.UnitTests.Common.Mappings
{
    using System;
    using System.Runtime.Serialization;
    using AutoMapper;
    using Taxes.Application.Common.Mappings;
    using Taxes.Application.Municipalities.Queries;
    using Taxes.Application.TaxSchedules.Queries.GetTaxSchedules;
    using Taxes.Domain.Entities;
    using Xunit;

    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(TaxSchedule), typeof(TaxScheduleResponse))]
        [InlineData(typeof(Municipality), typeof(MunicipalityResponse))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var instance = GetInstanceOf(source);

            _mapper.Map(instance, source, destination);
        }

        private object GetInstanceOf(Type type)
        {
            if (type.GetConstructor(Type.EmptyTypes) != null)
                return Activator.CreateInstance(type);

            // Type without parameterless constructor
            return FormatterServices.GetUninitializedObject(type);
        }
    }
}
