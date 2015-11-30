using System.Xml.Linq;

namespace Skybrud.Social.LinkedIn.Objects {
    
    /// <summary>
    /// Class representing a basic LinkedIn object derived from an instance of <code>XElement</code>.
    /// </summary>
    public class LinkedInObject {

        #region Properties

        public XElement XElement { get; private set; }

        #endregion

        #region COnstructors

        protected LinkedInObject(XElement xml) {
            XElement = xml;
        }

        #endregion

    }

}