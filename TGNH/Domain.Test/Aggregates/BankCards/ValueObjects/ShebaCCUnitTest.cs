using Domain.Aggregates.BankCards.ValueObjects;
using Resources;
using Resources.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Domain.Test.Aggregates.BankCards.ValueObjects
{
    public class ShebaCCUnitTest: object

    {
        [Fact]
        public void Null()
        {
            var result = ShebaCC.GetByValue(null);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.Required, DataDictionary.IR);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }
        [Fact]
        public void InCorrectValue1()
        {
            var result = ShebaCC.GetByValue(-1);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.IR);

            Assert.Equal(errorMessage, result.Errors[0].Message);

        }
    }
}
