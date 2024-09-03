using Domain.Aggregates.BankCards.ValueObjects;
using Resources;
using Resources.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.Aggregates.BankCards.ValueObjects
{
    public class BankPreNumberUnitTest : Object
    {
        [Fact]
        public void Null()
        {
            var result = BankPreNumber.GetByValue(null);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.Required, DataDictionary.BankPreNumber);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }
        [Fact]
        public void InCorrectValue1()
        {
            var result = BankPreNumber.GetByValue(-1);
            
            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.BankPreNumber);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }
    }
}
