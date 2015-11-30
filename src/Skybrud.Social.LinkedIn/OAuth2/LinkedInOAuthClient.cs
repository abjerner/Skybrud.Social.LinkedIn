using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.LinkedIn.Endpoints.Raw;
using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.OAuth2 {
    
    public class LinkedInOAuthClient : ILinkedInOAuthClient {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the app/client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the app/client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw groups endpoint.
        /// </summary>
        public LinkedInGroupsRawEndpoint Groups { get; private set; }

        /// <summary>
        /// Gets a reference to the raw pages endpoint.
        /// </summary>
        public LinkedInPagesRawEndpoint Pages { get; private set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public LinkedInUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        public LinkedInOAuthClient() {
            Groups = new LinkedInGroupsRawEndpoint(this);
            Pages = new LinkedInPagesRawEndpoint(this);
            Users = new LinkedInUsersRawEndpoint(this);
        }

        #endregion

        // Methods
        public LinkedInAccessTokenResponse GetAccessTokenFromAuthCode(string code) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
            {"grant_type", "authorization_code"},
            {"code", code},
            {"redirect_uri", RedirectUri},
            {"client_id", ClientId},
            {"client_secret", ClientSecret}
        };

            // Make the request and get the response body
            string response = SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://www.linkedin.com/uas/oauth2/accessToken", query);

            // Parse the response and return the access token
            return LinkedInAccessTokenResponse.Parse(response);

        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to LinkedIn's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return GetAuthorizationUrl(state, String.Join(",", scope));
        }

        public string GetAuthorizationUrl(string state, string scope = null) {
            NameValueCollection query = new NameValueCollection();
            query.Add("response_type", "code");
            query.Add("client_id", ClientId);
            query.Add("state", state);
            query.Add("scope", scope ?? "");
            query.Add("redirect_uri", RedirectUri);
            return ("https://www.linkedin.com/uas/oauth2/authorization?" + SocialUtils.NameValueCollectionToQueryString(query, true));
        }

        #region Methods from interface ILinkedInOAuthClient

        public string GetBasicProfile() {
            return GetBasicProfile(LinkedInConstants.BasicProfileDefaultFields);
        }

        public string GetBasicProfile(params string[] fields) {
            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/people/~",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                {"oauth2_access_token", AccessToken}
            };

            // Make the request and return the response body
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url, query);
        }

        public string GetGroupPosts(long groupId) {
            return GetGroupPosts(groupId, LinkedInConstants.GroupPostsDefaultFields);
        }

        public string GetGroupPosts(long groupId, string[] fields) {

            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/groups/" + groupId + "/posts",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                {"oauth2_access_token", AccessToken}
            };

            // Make the request and return the response body
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url, query);

        }

        #endregion

        #region Member methods

        public SocialHttpResponse DoHttpGetRequest(string url) {
            return DoHttpGetRequest(url, default(SocialQueryString));
        }

        public SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options) {
            return DoHttpGetRequest(url, options == null ? null : options.GetQueryString());
        }

        public SocialHttpResponse DoHttpGetRequest(string url, ILinkedInGetOptions options) {
            return DoHttpGetRequest(url, options == null ? null : options.GetQueryString());
        }

        public SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query) {

            // Append the access token to the query string
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                if (query == null) query = new SocialQueryString();
                query.Add("oauth2_access_token", AccessToken);
            }

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpGetRequest(url, query == null ? null : query.NameValueCollection);

            // Wrap the native response class
            return SocialHttpResponse.GetFromWebResponse(response);

        }

        #endregion

    }

}
