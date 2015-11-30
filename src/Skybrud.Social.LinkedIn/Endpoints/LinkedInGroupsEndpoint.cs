using Skybrud.Social.LinkedIn.Endpoints.Raw;

namespace Skybrud.Social.LinkedIn.Endpoints {

    public class LinkedInGroupsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public LinkedInService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public LinkedInGroupsRawEndpoint Raw {
            get { return Service.Client.Groups; }
        }

        #endregion

        #region Constructors

        internal LinkedInGroupsEndpoint(LinkedInService service) {
            Service = service;
        }

        #endregion

    }


}