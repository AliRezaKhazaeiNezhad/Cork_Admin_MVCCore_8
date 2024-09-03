
using Resources;
using Resources.Messages;
using Domain.Aggregates.Accounts.ValueObjects;

namespace Domain.Test.Aggregates.Accounts.ValueObjects
{
    public class AccountTypeUnitTest : object
    {
        [Fact]
        public void Null()
        {
            var result = AccountType.GetByValue(null);

            Assert.True(result.IsFailed); 
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.Required, DataDictionary.AccountType);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }

        [Fact]
        public void InCorrectValue1()
        {
            var result = AccountType.GetByValue(-1);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.AccountType);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }

        [Fact]
        public void InCorrectValue2()
        {
            var result = AccountType.GetByValue(3);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.AccountType);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void CorrectRial()
        {
            var result = AccountType.GetByValue(0);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);
        }

        [Fact]
        public void CorrectSilverCoin()
        {
            var result = AccountType.GetByValue(1);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);
        }

        [Fact]
        public void CorrectGoldenCoin()
        {
            var result = AccountType.GetByValue(2);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);
        }
    }
}
