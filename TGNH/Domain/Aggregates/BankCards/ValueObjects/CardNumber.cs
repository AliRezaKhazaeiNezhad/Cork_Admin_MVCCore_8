
using KHN;
using Resources;
using FluentResults;
using Domain.SeedWork;
using Resources.Messages;

namespace Domain.Aggregates.BankCards.ValueObjects
{
    public class CardNumber : ValueObject
    {
        public const int FixLength = 16;

        public const string Pattern = "^[0-9]*$";


        private CardNumber() : base()
        {

        }

        private CardNumber(string value) : this()
        {
            Value = value;
        }

        public string Value { get; }


        public static Result<CardNumber> Create(string value)
        {
            var result = new Result<CardNumber>();

            value = value.Fix();


            if (value is null)
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.CardNumber);

                result.WithError(errorMessage);

                return result;
            }


            if (value.Length != FixLength)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.CardNumber, FixLength);

                result.WithError(errorMessage);

                return result;
            }


            if (System.Text.RegularExpressions.Regex.IsMatch(value, Pattern) == false)
            {
                string errorMessage = string.Format(Validations.InCorrectFormat, DataDictionary.CardNumber, FixLength);

                result.WithError(errorMessage);

                return result;
            }


            var returnValue = new CardNumber(value);

            result.WithValue(returnValue);

            return result;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
