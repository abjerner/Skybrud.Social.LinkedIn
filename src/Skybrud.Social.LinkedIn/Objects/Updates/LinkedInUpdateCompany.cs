using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdateCompany : LinkedInJsonObject {

        #region Properties

        public int Id { get; private set; }
        public string Name { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdateCompany(JObject obj) : base(obj) {
            Id = obj.GetInt32("id");
            Name = obj.GetString("name");
        }

        #endregion

        #region Static methods

        public static LinkedInUpdateCompany Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdateCompany(obj);
        }

        #endregion
    }
}