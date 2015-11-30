using System.Xml.Linq;
using Skybrud.Social.LinkedIn.ExtensionMethods;

namespace Skybrud.Social.LinkedIn.Objects.Locations {

    public class LinkedInLocation : LinkedInObject {

        #region Properties

        public string Name { get; private set; }

        public LinkedInCountry Country { get; private set; }

        #endregion

        #region Constructors

        private LinkedInLocation(XElement xml) : base(xml) {
            Name = xml.GetElementValue("name");
            Country = xml.GetElement("country", LinkedInCountry.Parse);
        }

        #endregion

        #region Static methods

        public static LinkedInLocation Parse(XElement xml) {
            return xml == null ? null : new LinkedInLocation(xml);
        }

        #endregion
    
    }
}