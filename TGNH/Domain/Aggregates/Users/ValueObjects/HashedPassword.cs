using Domain.SeedWork;
using FluentResults;
using Resources;
using Resources.Messages;
using System.Text.RegularExpressions;


namespace Domain.Aggregates.Users.ValueObjects
{
    public class HashedPassword :ValueObject
    {
        public const int Fixlength = 23;

        public const string Pattern = "^[a-f0-9]+$";

        private HashedPassword()  : base()
        {

        }
        private HashedPassword(string value) : this() 
        {
            Value = value;
        }
        public string Value { get; private set; }
        public static Result<HashedPassword> Create(string value)
        {
            var result = new Result<HashedPassword>();

            if (string.IsNullOrWhiteSpace(value) || value.Length != Fixlength)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.HashedPassword);
                result.WithError(errorMessage);
                return result;
            }
            if (!Regex.IsMatch(value, Pattern))
            {
                string errorMessage = string.Format(Validations.IsMactch, DataDictionary.HashedPassword);
                result.WithError(errorMessage);
                return result;
            }
            if(value != value.ToLower()) 
            {
                string errorMessage = string.Format(Validations.LowerCase, DataDictionary.HashedPassword);

                result.WithError(errorMessage);
                return result;
            }
            return result.WithValue(new HashedPassword(value));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
