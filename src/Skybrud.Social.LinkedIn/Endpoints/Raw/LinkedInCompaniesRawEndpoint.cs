using System;
using Skybrud.Social.Http;
using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.Endpoints.Raw {
    
    public class LinkedInCompaniesRawEndpoint {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the LinkedIn OAuth client.
        /// </summary>
        public ILinkedInOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal LinkedInCompaniesRawEndpoint(ILinkedInOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public SocialHttpResponse GetUpdates(int companyId) {
            return GetUpdates(companyId, new string[0]);
        }

        public SocialHttpResponse GetUpdates(int companyId, params string[] fields) {

            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/companies/" + companyId + "/updates?format=json",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Make the request to the API
            return Client.DoHttpGetRequest(url);

        }

        #endregion

    }

}