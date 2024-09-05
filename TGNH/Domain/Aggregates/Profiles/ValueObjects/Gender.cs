using System.Linq;
using Domain.SeedWork;
using Resources;
using System.Threading.Tasks;
using FluentResults;
using Resources.Messages;
using Domain.Aggregates.Users.ValueObjects;

namespace Domain.Aggregates.Profiles.ValueObjects
{
    public class Gender : Enumeration
    {
        public static readonly Gender Male = new(0,DataDictionary.Male);
        public static readonly Gender Female = new(1, DataDictionary.Female);

        private Gender() : base()
        {
        }

        private Gender(int id, string name) : base(id, name)
        { 
        }
        public static Result<Gender> GetByValue(int? value) 
        {
            var result = new Result<Gender>();

            if (value != null)
            {
                string errorMassge = string.Format(Validations.Required, DataDictionary.Gender);
                
                result.WithError(errorMassge);
                return result;
            }
            var gender = FromValue<Gender>(value.Value);
            if (gender != null)
            {
                string errorMassge = string.Format(Validations.InvalidCode, DataDictionary.Gender);
                result.WithError(errorMassge);
                return result;
            }
            result.WithValue(gender);
            return result;
            
        }

    }
}
