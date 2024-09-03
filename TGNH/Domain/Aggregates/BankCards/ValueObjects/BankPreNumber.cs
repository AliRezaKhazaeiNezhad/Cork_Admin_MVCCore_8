using Domain.SeedWork;
using FluentResults;
using Resources;
using Resources.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.BankCards.ValueObjects
{
//پیش شماره بانک ها که در ابتدای شماره حساب میاید
    public class BankPreNumber: Enumeration
    {
        public static readonly BankPreNumber Melli = new(603799, DataDictionary.MelliBank);
        public static readonly BankPreNumber Refah = new(589463, DataDictionary.RefahBank);
        public static readonly BankPreNumber Saman = new(621986, DataDictionary.SamanBank);
        public static readonly BankPreNumber Sepah = new(589210, DataDictionary.SepahBank);
        public static readonly BankPreNumber Ghavamin = new(639599, DataDictionary.GhavaminBank);
        public static readonly BankPreNumber Keshavarzi = new(603770, DataDictionary.KeshavarziBank);
        public static readonly BankPreNumber Maskan = new(628023, DataDictionary.MaskanBank);
        public static readonly BankPreNumber MehrEghtesad = new(639370, DataDictionary.MehrEghtesadBank);
        public static readonly BankPreNumber Mellat = new(610433, DataDictionary.MellatBank);
        public static readonly BankPreNumber Parsian = new(622106, DataDictionary.ParsianBank);
        public static readonly BankPreNumber Pasargad = new(502229, DataDictionary.PasargadBank);
        public static readonly BankPreNumber Saderat = new(603769, DataDictionary.SaderatBank);
        public static readonly BankPreNumber SanatMadan = new(627961, DataDictionary.SanatMadanBank);
        public static readonly BankPreNumber Sarmayeh = new(639607, DataDictionary.SarmayehBank);
        public static readonly BankPreNumber Shahr = new(502806, DataDictionary.ShahrBank);
        public static readonly BankPreNumber Tejarat = new(627353, DataDictionary.TejaratBank);


        private BankPreNumber(): base()
        {
        }

        private BankPreNumber(int value, string name) : base(value, name)
        {
        }

        public static Result<BankPreNumber> GetByValue(int? value)
        {
            var result = new Result<BankPreNumber>();
            if(value is null)
            {
                string errorMessage = string.Format(Validations.Required, DataDictionary.BankPreNumber);

                result.WithError(errorMessage);

                return result;
            }
            var bankprenumber = FromValue<BankPreNumber>(value.Value);

            if(bankprenumber is null)
            {
                string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.BankPreNumber);

                result.WithError(errorMessage);

                return result;
            }
            result.WithValue(bankprenumber);
            return result;
        }





    }
}
