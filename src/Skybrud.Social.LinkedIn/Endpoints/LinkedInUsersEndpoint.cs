using Skybrud.Social.LinkedIn.Endpoints.Raw;
using Skybrud.Social.LinkedIn.Responses.Users;

namespace Skybrud.Social.LinkedIn.Endpoints {

    public class LinkedInUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public LinkedInService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public LinkedInUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal LinkedInUsersEndpoint(LinkedInService service) {
            Service = service;
        }

        #endregion

        #region Membmer methods

        public LinkedInGetUserResponse GetUser(string user) {
            return LinkedInGetUserResponse.ParseResponse(Raw.GetUser(user));
        }

        public LinkedInGetUserResponse GetUser(string user, params string[] fields) {
            return LinkedInGetUserResponse.ParseResponse(Raw.GetUser(user, fields));
        }

        #endregion

    }


}