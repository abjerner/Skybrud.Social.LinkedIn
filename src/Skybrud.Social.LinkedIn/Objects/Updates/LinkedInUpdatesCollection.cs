using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdatesCollection : LinkedInJsonObject {

        #region Properties

        public LinkedInUpdate[] Values { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdatesCollection(JObject obj) : base(obj) {
            Values = obj.GetArray("values", LinkedInUpdate.Parse);
        }

        #endregion

        #region Static methods

        public static LinkedInUpdatesCollection Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdatesCollection(obj);
        }

        #endregion
    }
}