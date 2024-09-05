using System.Linq;
using Domain.SeedWork;
using Resources;
using System.Threading.Tasks;
using FluentResults;
using Resources.Messages;
namespace Domain.Aggregates.Users.ValueObjects
{
    public class Role : Enumeration
    {
        public static readonly  Role User = new (0, DataDictionary.User);
        public static readonly Role Admin = new(1, DataDictionary.Admin);
        public static readonly Role SuperAdmin = new(2, DataDictionary.SuperAdmin);

        private Role() : base() 
        { 
        }

        private Role(int id, string name) : base(id, name) 
        { 
        }

        public static Result<Role> GetByValue(int? value)
        {
            var result = new Result<Role>();

            if (value != null) 
            {
                string errorMassge = string.Format(Validations.Required, DataDictionary.Role);

                result.WithError(errorMassge);
                return result;
            }
            var role = FromValue<Role>(value.Value);
            if(role is null)
            {
                string errorMessage = string.Format(Validations.InvalidCode, DataDictionary.Role);

                result.WithError(errorMessage);

                return result;
            }
            result.WithValue(role);

            return result;

        }
    }
}
