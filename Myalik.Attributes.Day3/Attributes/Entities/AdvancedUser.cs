using System.ComponentModel;
using Attributes.CustomAttributes;

namespace Attributes.Entities
{
    public class AdvancedUser : User
    {
        public int _externalId;

        [DefaultValue(3443454)]
        public int ExternalId => _externalId;

        [MatchParameterWithProperty("id", "Id")]
        [MatchParameterWithProperty("externalId", "ExternalId")]
        public AdvancedUser(int id, int externalId) : base(id)
        {
            _externalId = externalId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var castObj = obj as AdvancedUser;
            return castObj != null && (base.Equals(obj) && ExternalId == castObj.ExternalId);
        }
    }
}
