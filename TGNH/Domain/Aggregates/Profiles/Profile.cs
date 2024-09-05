
using Domain.Aggregates.Profiles.ValueObjects;

namespace Domain.Aggregates.Profiles
{
    public class Profile
    {

        public Gender Gender { get;private set; }
        public Firstname Firstname { get;private set; }
        public Lastname Lastname { get;private set; }
        public NationalCode NationalCode { get;private set; }
        public BirthDate BirthDate { get;private set; }
        public Firstname Fathername { get;private set; }
        public PassportNumber PassportNumber { get;private set; }
<<<<<<< HEAD
=======
        public Firstname FirstName { get;private set; }
>>>>>>> 5fcb96b3edf7d8756b52ae2eb83b4f96ad9171ee
    }
}
