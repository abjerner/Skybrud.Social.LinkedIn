using System.Xml.Linq;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Objects.Locations {
    
    public class LinkedInCountry : LinkedInObject {
        
        #region Properties

        public string Code { get; private set; }

        #endregion

        #region Constructors

        private LinkedInCountry(XElement xml) : base(xml) {
            Code = xml.GetElementValue("code");
        }

        #endregion

        #region Static methods

        public static LinkedInCountry Parse(XElement xml) {
            return xml == null ? null : new LinkedInCountry(xml);
        }

        #endregion

    }

}