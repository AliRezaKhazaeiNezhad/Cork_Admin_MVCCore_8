using Domain.Aggregates.Users.ValueObjects;
using Domain.SeedWork;
using FluentResults;
using Resources;
using Resources.Messages;
using System.Text.RegularExpressions;
namespace Domain.Aggregates.Profiles.ValueObjects
{
    
    public class NationalCode : ValueObject
    {
        public const int FixLength = 10;

        private static readonly Regex NationalCodePattern = new Regex("^[0-9]{10}$");
        
        private NationalCode():base()
        {
        }
        private NationalCode(string value): this()
        {
            Value = value;
        }
        public string Value { get; private set; }

        public static Result<NationalCode> crete(string value)
        {
            var result = new Result<NationalCode>();

            if (string.IsNullOrEmpty(value)) 
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.NationalCode);
                result.WithError(errorMessage);
                return result;
            }
            value = value.PadLeft(FixLength,'0');

            if(value.Length != FixLength)
            {
                string errorMessage = string.Format(Validations.FixLength,DataDictionary.NationalCode);
                result.WithError(errorMessage);
                return result;
            }
            if (!NationalCodePattern.IsMatch(value))
            {
                string errorMessage = string.Format(Validations.IsMactch, DataDictionary.NationalCode);
                result.WithError(errorMessage);
                return result;
            }
            if (!IsValidNationalCode(value))
            {
                string errorMessage = string.Format(Validations.InValidValue, DataDictionary.NationalCode);
                result.WithError(errorMessage);
                return result;
            }
            return result.WithValue(new NationalCode(value));
        }
        private static bool IsValidNationalCode(string nationalCode)
        {
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
            }
            int remainder = sum % 11;
            int controlDigit = int.Parse(nationalCode[9].ToString());

            return (remainder < 2 && controlDigit == remainder) || (remainder >= 2 && controlDigit ==( 11 - remainder));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
