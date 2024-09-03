using KHN;
using Resources;
using Resources.Messages;
using Domain.Aggregates.Accounts.ValueObjects;

namespace Domain.Test.Aggregates.Accounts.ValueObjects
{
    public class AddressUnitTest : object
    {
        [Fact]
        public void IsNull()
        {
            var result = Address.Create(null);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.Required, DataDictionary.AccountAddress);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void ShortLength()
        {
            var input = Guid.NewGuid().ToString();

            input = input.Substring(0, input.Length - 2);

            var result = Address.Create(input);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.AccountAddress, Address.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void LongLength()
        {
            var input = $"{Guid.NewGuid()}-";

            var result = Address.Create(input);

            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.AccountAddress, Address.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void InCorrectWithWiteSpaceBetween()
        {
            var input = Guid.NewGuid().ToString();

            input = $"{input.Substring(0, 19)}         {input.Substring(19, 17)}";

            var result = Address.Create(input);


            Assert.True(result.IsFailed);
            Assert.False(result.IsSuccess);

            string errorMessage = string.Format(Validations.FixLength, DataDictionary.AccountAddress, Address.FixLength);

            Assert.Equal(errorMessage, result.Errors[0].Message);
        }


        [Fact]
        public void CorrectWithWiteSpaceStart()
        {
            var input = $"        {Guid.NewGuid()}";

            var result = Address.Create(input);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);

            input = $"TGNH-{input.Fix()}";

            Assert.Equal(result.Value.Value, input);
        }


        [Fact]
        public void CorrectWithWiteSpaceEnd()
        {
            var input = $"{Guid.NewGuid()}        ";

            var result = Address.Create(input);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);

            input = $"TGNH-{input.Fix()}";

            Assert.Equal(result.Value.Value, input);
        }


        [Fact]
        public void Correct()
        {
            var input = Guid.NewGuid().ToString();

            var result = Address.Create(input);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailed);

            input = $"TGNH-{input}";

            Assert.Equal(result.Value.Value, input);
        }
    }
}
