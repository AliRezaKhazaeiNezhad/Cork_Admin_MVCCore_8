using Domain.SeedWork;
using FluentResults;
using Resources;
using Resources.Messages;
using System.Text.RegularExpressions;
namespace Domain.Aggregates.Users.ValueObjects
{
    public class ActivationCode : ValueObject
    {
        public const int FixLength = 6;

        public const string Pattern = "^[0-9]+$";
       
        private ActivationCode() : base()
        {

        }
        private ActivationCode(string value) : this() 
        {
            Value = value;
        }
        public string Value { get; private set; }

        public static Result<ActivationCode> Create(string value) 
        {
            var result = new Result<ActivationCode>();


            if (value.Length > FixLength)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.ActivationCode);
                result.WithError(errorMessage);
                return result;
            }
            if(value is null) 
            {
                string errorMassge = string.Format(Validations.Required, DataDictionary.ActivationCode);
                result.WithError(errorMassge);
                return result;
            }
            if (!Regex.IsMatch(value, Pattern))
            {
                string errorMessage = string.Format(Validations.IsMactch, DataDictionary.ActivationCode);
                result.WithError(errorMessage);
                return result;
            }
            return result.WithValue(new ActivationCode(value));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
