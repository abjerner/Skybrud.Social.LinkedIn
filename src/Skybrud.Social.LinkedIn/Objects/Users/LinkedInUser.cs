using System.Xml.Linq;
using Skybrud.Social.LinkedIn.ExtensionMethods;
using Skybrud.Social.LinkedIn.Objects.Locations;

namespace Skybrud.Social.LinkedIn.Objects.Users {

    public class LinkedInUser : LinkedInObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public string Id { get; private set; }
        
        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; private set; }
        
        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; private set; }
        
        /// <summary>
        /// Gets the picture URL of the user.
        /// </summary>
        public string PictureUrl { get; private set; }

        /// <summary>
        /// Gets the headline of the user.
        /// </summary>
        public string Headline { get; private set; }

        /// <summary>
        /// Gets the URL of the public profile of the user.
        /// </summary>
        public string PublicProfileUrl { get; private set; }

        public LinkedInLocation Location { get; private set; }

        public string Industry { get; private set; }
        
        #endregion

        #region Constructors

        private LinkedInUser(XElement xml) : base(xml) {
            Id = xml.GetElementValue("id");
            FirstName = xml.GetElementValue("first-name");
            LastName = xml.GetElementValue("last-name");
            PictureUrl = xml.GetElementValue("picture-url");
            Headline = xml.GetElementValue("headline");
            PublicProfileUrl = xml.GetElementValue("public-profile-url");
            Location = xml.GetElement("location", LinkedInLocation.Parse);
            Industry = xml.GetElementValue("industry");
        }

        #endregion

        #region Static methods

        public static LinkedInUser Parse(XElement xml) {
            return xml == null ? null : new LinkedInUser(xml);
        }

        #endregion

    }

}