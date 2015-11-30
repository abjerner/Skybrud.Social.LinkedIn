using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.LinkedIn.Endpoints.Raw;

namespace Skybrud.Social.LinkedIn.Interfaces {
    
    public interface ILinkedInOAuthClient {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw groups endpoint.
        /// </summary>
        LinkedInGroupsRawEndpoint Groups { get; }

        /// <summary>
        /// Gets a reference to the raw pages endpoint.
        /// </summary>
        LinkedInPagesRawEndpoint Pages { get; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        LinkedInUsersRawEndpoint Users { get; }

        #endregion

        #region Member methods

        SocialHttpResponse DoHttpGetRequest(string url);

        SocialHttpResponse DoHttpGetRequest(string url, IGetOptions options);

        SocialHttpResponse DoHttpGetRequest(string url, ILinkedInGetOptions options);

        SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query);

        #endregion

        [Obsolete]
        string GetGroupPosts(long groupId);

        [Obsolete]
        string GetGroupPosts(long groupId, string[] fields);

        [Obsolete]
        string GetBasicProfile();

        [Obsolete]
        string GetBasicProfile(string[] fields);

    }

}
