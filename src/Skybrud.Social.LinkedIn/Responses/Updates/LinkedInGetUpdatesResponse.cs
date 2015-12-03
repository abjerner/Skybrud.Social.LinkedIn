using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.LinkedIn.Objects.Updates;

namespace Skybrud.Social.LinkedIn.Responses.Updates
{
    public class LinkedInGetUpdatesResponse : LinkedInResponse<LinkedInUpdatesCollection>
    {
        #region Constructors

        private LinkedInGetUpdatesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>LinkedInGetUpdatesResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>LinkedInGetUserResponse</code>.</returns>
        public static LinkedInGetUpdatesResponse ParseResponse(SocialHttpResponse response)
        {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Parse the XML into an instance of XElement
            JObject json = JObject.Parse(response.Body);

            // Initialize the response object
            return new LinkedInGetUpdatesResponse(response)
            {
                Body = LinkedInUpdatesCollection.Parse(json)
            };

        }

        #endregion
    }
}
