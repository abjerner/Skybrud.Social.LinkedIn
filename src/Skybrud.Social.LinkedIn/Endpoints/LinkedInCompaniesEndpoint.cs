using Skybrud.Social.LinkedIn.Endpoints.Raw;
using Skybrud.Social.LinkedIn.Responses.Updates;

namespace Skybrud.Social.LinkedIn.Endpoints
{
    public class LinkedInCompaniesEndpoint {

        #region Properties

        /// <summary>
        ///     Gets a reference to the GitHub service.
        /// </summary>
        public LinkedInService Service { get; private set; }

        /// <summary>
        ///     Gets a reference to the raw endpoint.
        /// </summary>
        public LinkedInCompaniesRawEndpoint Raw
        {
            get { return Service.Client.Companies; }
        }

        #endregion

        #region Constructors

        internal LinkedInCompaniesEndpoint(LinkedInService service) {
            Service = service;
        }

        #endregion

        #region Public methods

        public LinkedInGetUpdatesResponse GetUpdates(int companyId) {
            return GetUpdates(companyId, new string[0]);
        }

        public LinkedInGetUpdatesResponse GetUpdates(int companyId, params string[] fields) {
            return LinkedInGetUpdatesResponse.ParseResponse(Raw.GetUpdates(companyId));
        }

        #endregion
    }
}