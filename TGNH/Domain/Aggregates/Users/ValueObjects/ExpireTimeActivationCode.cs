
using Domain.SeedWork;
using FluentResults;
using Resources.Messages;
using Resources;
using System.Text.RegularExpressions;

namespace Domain.Aggregates.Users.ValueObjects
{
    public class ExpireTimeActivationCode : ValueObject
    {
        public DateTime CreatedAt { get;private set; }
         public string Value { get;private set; }

        private const int ExpirationTimeInSeconds = 90;

        private ExpireTimeActivationCode()  : base()
        {
        }
        private ExpireTimeActivationCode(string value) 
        {
            Value = value;
            CreatedAt = DateTime.UtcNow;
        }
        public static Result<ExpireTimeActivationCode> Create(string value)
        {
            var result = new Result<ExpireTimeActivationCode>();

            if(value.Length > 6)
            {
                string errorMessage = string.Format(Validations.FixLength, DataDictionary.ExpireTimeActivationCode);
                result.WithError(errorMessage);
                return result;
            }
            if (!Regex.IsMatch(value,"^[0-9]+$"))
            {
                string errorMessage = string.Format(Validations.IsMactch, DataDictionary.ExpireTimeActivationCode);
                result.WithError(errorMessage);
                return result;
            }
            return result.WithValue(new ExpireTimeActivationCode(value));
        }
        public bool IsExpired()
        {
            return (DateTime.UtcNow - CreatedAt).TotalSeconds > ExpirationTimeInSeconds;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

    }
}
