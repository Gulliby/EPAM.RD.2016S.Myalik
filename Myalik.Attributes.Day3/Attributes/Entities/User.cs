using System.ComponentModel;
using Attributes.CustomAttributes;
using Attributes.CustomValidationAttributes;

namespace Attributes.Entities
{
    [InstantiateUser("Alexander", "Alexandrov")]
    [InstantiateUser(2, "Semen", "Semenov")]
    [InstantiateUser(3, "Petr", "Petrov")]
    public class User
    {
        [IntValidator(1, 1000)]
        private int _id;

        [DefaultValue(1)]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        [StringValidator(30)]
        public string FirstName { get; set; }

        [StringValidator(20)]
        public string LastName { get; set; }

        [MatchParameterWithProperty("id", "Id")]
        public User(int id)
        {
            _id = id;
        }
    }
}
