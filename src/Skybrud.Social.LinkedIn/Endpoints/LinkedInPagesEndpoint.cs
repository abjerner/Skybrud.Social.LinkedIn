using Skybrud.Social.LinkedIn.Endpoints.Raw;

namespace Skybrud.Social.LinkedIn.Endpoints {

    public class LinkedInPagesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public LinkedInService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public LinkedInPagesRawEndpoint Raw {
            get { return Service.Client.Pages; }
        }

        #endregion

        #region Constructors

        internal LinkedInPagesEndpoint(LinkedInService service) {
            Service = service;
        }

        #endregion

    }


}