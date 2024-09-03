using Resources;
using FluentResults;
using Domain.SeedWork;
using Resources.Messages;



namespace Domain.Aggregates.BankCards.ValueObjects
{
    //دو رقم ابتدایی مربوطه به شماره شبا
    public class ShebaCC : Enumeration
    {
        public static readonly ShebaCC IR = new(0, DataDictionary.IR);


        private ShebaCC() :base()
        {
        }

        private ShebaCC(int value , string name ) : base(value, name)
        {
        }


        public static Result<ShebaCC> GetByValue(int? value)
        {
            var result = new Result<ShebaCC>();

            if(value is null)
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.IR);

                result.WithError(errorMessage);

                return result;
            }

            var shebacc = FromValue<ShebaCC>(value.Value);

            if (shebacc is null)
            {
                string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.IR);

                result.WithError(errorMessage);

                return result;
            }

            result.WithValue(shebacc);

            return result;
        }
    }
}
