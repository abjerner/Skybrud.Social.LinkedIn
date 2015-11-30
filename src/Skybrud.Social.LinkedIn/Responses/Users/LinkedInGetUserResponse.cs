using System;
using System.Xml.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.LinkedIn.Objects.Users;

namespace Skybrud.Social.LinkedIn.Responses.Users {

    public class LinkedInGetUserResponse : LinkedInResponse<LinkedInUser> {

        #region Constructors

        private LinkedInGetUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>LinkedInGetUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>LinkedInGetUserResponse</code>.</returns>
        public static LinkedInGetUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Parse the XML into an instance of XElement
            XElement xml = XElement.Parse(response.Body);

            // Initialize the response object
            return new LinkedInGetUserResponse(response) {
                Body = LinkedInUser.Parse(xml)
            };

        }

        #endregion

    }

}