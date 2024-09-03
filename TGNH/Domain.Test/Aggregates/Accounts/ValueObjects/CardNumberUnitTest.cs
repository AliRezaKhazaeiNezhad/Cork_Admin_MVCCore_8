
using Resources;
using Resources.Messages;
using Domain.Aggregates.BankCards.ValueObjects;

namespace Domain.Test.Aggregates.Accounts.ValueObjects
{
    public class CardNumberUnitTest
    {
        [Fact]
        public void Null()
        {
            var result = CardNumber.Create(null);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.Required, DataDictionary.CardNumber);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }

        [Fact]
        public void MinLength()
        {
            var result = CardNumber.Create("123456789012345");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }

        [Fact]
        public void MaxLength()
        {
            var result = CardNumber.Create("12345678901234567");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }



        [Fact]
        public void CardNumberEndWhiteSpace()
        {
            var result = CardNumber.Create("12345678901234567                                   ");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void CardNumberStartWhiteSpace()
        {
            var result = CardNumber.Create("                                   12345678901234567");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void CardNumberBetweenWhiteSpace()
        {
            var result = CardNumber.Create("123         4567890123456   7");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void Alphabet()
        {
            var result = CardNumber.Create("abcdefghijklmnop");

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.InCorrectFormat, DataDictionary.CardNumber, CardNumber.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void Correct()
        {
            var result = CardNumber.Create("1234567890123456");

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);
        }


    }
}
