using System;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.LinkedIn.Responses {

    /// <summary>
    /// Class representing a response from the LinkedIn API.
    /// </summary>
    public class LinkedInResponse : SocialResponse {

        #region Constructors

        protected LinkedInResponse(SocialHttpResponse response) : base(response) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            throw new Exception("Oh noes!!!\n\n" + response.Body);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the LinkedIn API.
    /// </summary>
    public class LinkedInResponse<T> : LinkedInResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected LinkedInResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}