using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdateCompanyStatus : LinkedInJsonObject {

        #region Properties

        public LinkedInUpdateShare Share { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdateCompanyStatus(JObject obj) : base(obj) {
            Share = obj.GetObject("share", LinkedInUpdateShare.Parse);
        }

        #endregion

        #region Static methods

        public static LinkedInUpdateCompanyStatus Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdateCompanyStatus(obj);
        }

        #endregion
    }
}