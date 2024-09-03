using KHN;
using Resources;
using FluentResults;
using Domain.SeedWork;
using Resources.Messages;

namespace Domain.Aggregates.Accounts.ValueObjects
{
    public class Address : ValueObject
    {

        public const int FixLength = 36;


        private Address() : base()
        {

        }

        private Address(string value): this()
        {
            Value = value;
        }

        public string Value { get; }



        public static Result<Address> Create(string value)
        {
            var result = new Result<Address>();

            value = value.Fix();

            if (value is null)
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.AccountAddress);

                result.WithError(errorMessage);

                return result;
            }

            if (value.Length != FixLength)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.AccountAddress, FixLength);

                result.WithError(errorMessage);

                return result;
            }

            value = $"TGNH-{value}";

            var returnValue = new Address(value);

            result.WithValue(returnValue);

            return result;
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
