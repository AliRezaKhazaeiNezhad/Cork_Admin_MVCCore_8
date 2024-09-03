using Resources;
using FluentResults;
using Domain.SeedWork;
using Resources.Messages;

namespace Domain.Aggregates.Accounts.ValueObjects
{
    public class AccountType : Enumeration
    {
        public static readonly AccountType Rial = new(0, DataDictionary.Rial);
        public static readonly AccountType SilverCoin = new(1, DataDictionary.SilverCoin);
        public static readonly AccountType GoldenCoin = new(2, DataDictionary.GoldenCoin);


        private AccountType() : base()
        {
        }

        private AccountType(int value, string name) : base(value, name)
        {
        }


        public static Result<AccountType> GetByValue(int? value)
        {
            var result = new Result<AccountType>();

            if (value is null)
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.AccountType);

                result.WithError(errorMessage);

                return result;
            }

            var accountType = FromValue<AccountType>(value.Value);

            if (accountType is null)
            {
                string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.AccountType);

                result.WithError(errorMessage);

                return result;
            }

            result.WithValue(accountType);

            return result;
        }
    }
}
