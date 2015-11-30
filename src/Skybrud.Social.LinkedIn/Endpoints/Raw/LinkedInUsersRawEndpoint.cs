using System;
using Skybrud.Social.Http;
using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.Endpoints.Raw {
    
    public class LinkedInUsersRawEndpoint {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the LinkedIn OAuth client.
        /// </summary>
        public ILinkedInOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal LinkedInUsersRawEndpoint(ILinkedInOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public SocialHttpResponse GetUser(string user) {
            return GetUser(user, LinkedInConstants.BasicProfileDefaultFields);
        }

        public SocialHttpResponse GetUser(string user, params string[] fields) {
            
            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/people/" + user,
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Make the request to the API
            return Client.DoHttpGetRequest(url);
        
        }

        #endregion

    }


}