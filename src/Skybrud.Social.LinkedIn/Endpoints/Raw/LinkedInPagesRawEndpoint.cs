using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.Endpoints.Raw {
    
    public class LinkedInPagesRawEndpoint {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the LinkedIn OAuth client.
        /// </summary>
        public ILinkedInOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal LinkedInPagesRawEndpoint(ILinkedInOAuthClient client) {
            Client = client;
        }

        #endregion

    }

}