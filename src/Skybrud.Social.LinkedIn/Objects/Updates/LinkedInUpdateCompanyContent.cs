using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdateCompanyContent : LinkedInJsonObject {

        #region Properties

        public LinkedInUpdateCompany Company { get; private set; }

        public LinkedInUpdateCompanyStatus CompanyStatusUpdate { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdateCompanyContent(JObject obj) : base(obj) {
            Company = obj.GetObject("company", LinkedInUpdateCompany.Parse);

            CompanyStatusUpdate = obj.GetObject("companyStatusUpdate", LinkedInUpdateCompanyStatus.Parse);
        }

        #endregion

        #region Static methods

        public static LinkedInUpdateCompanyContent Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdateCompanyContent(obj);
        }

        #endregion
    }
}