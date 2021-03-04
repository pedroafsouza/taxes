namespace Taxes.Application.UnitTests.Common.Exceptions
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;
    using Xunit;
    using Taxes.Application.Common.Exceptions;
    using FluentAssertions;

    public class ValidationExceptionTests
    {
        [Fact]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Value", "taxe value must to be aboe 0."),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Value" });
            actual["Value"].Should().BeEquivalentTo(new string[] { "taxe value must to be aboe 0." });
        }

        [Fact]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Date", "date needs to be after than today."),
                new ValidationFailure("Date", "date needs to be before 30 days."),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Password", "Date" });

            actual["Date"].Should().BeEquivalentTo(new string[]
            {
                "date needs to be after than today.",
                "date needs to be before 30 days.",
            });

            actual["Password"].Should().BeEquivalentTo(new string[]
            {
                "must contain lower case letter",
                "must contain upper case letter",
                "must contain at least 8 characters",
                "must contain a digit",
            });
        }
    }
}
