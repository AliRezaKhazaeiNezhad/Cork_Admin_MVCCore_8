using Domain.Aggregates.Users.ValueObjects;
using Domain.SeedWork;
using FluentResults;
using Resources;
using Resources.Messages;
using System.Text.RegularExpressions;
namespace Domain.Aggregates.Profiles.ValueObjects
{
    public class Lastname : ValueObject
    {
        public const int FixLength = 15;

        public const string Pattern = "^[a-z]+$";

        private Lastname() : base()
        {
        }
        private Lastname(string value) : this()
        {
            Value = value;
        }
        public string Value { get; private set; }

        public static Result<Lastname> Create(string value)
        {
            var result = new Result<Lastname>();
            if (value is null)
            {
                string errorMassge = string.Format(Validations.Required, DataDictionary.LastName);
                result.WithError(errorMassge);
                return result;
            }
            if (value.Length > FixLength)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.LastName);
                result.WithError(errorMessage);
                return result;
            }
            if (!Regex.IsMatch(value, Pattern))
            {
                string errorMessage = string.Format(Validations.IsMactch, DataDictionary.LastName);
                result.WithError(errorMessage);
                return result;
            }
            return result.WithValue(new Lastname(value));

        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
