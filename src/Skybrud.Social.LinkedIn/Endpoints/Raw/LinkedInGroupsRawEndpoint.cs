using System;
using Skybrud.Social.Http;
using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.Endpoints.Raw {
    
    public class LinkedInGroupsRawEndpoint {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the LinkedIn OAuth client.
        /// </summary>
        public ILinkedInOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal LinkedInGroupsRawEndpoint(ILinkedInOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of posts of the group with the specified <code>groupId</code>.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetGroupPosts(long groupId) {
            return GetGroupPosts(groupId, LinkedInConstants.GroupPostsDefaultFields);
        }

        /// <summary>
        /// Gets a list of posts of the group with the specified <code>groupId</code>.
        /// </summary>
        /// <param name="groupId">The ID of the group.</param>
        /// <param name="fields">An array of the fields to be returned.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetGroupPosts(long groupId, string[] fields) {

            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/groups/" + groupId + "/posts",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Make the request to the API
            return Client.DoHttpGetRequest(url);

        }

        #endregion

    }

}