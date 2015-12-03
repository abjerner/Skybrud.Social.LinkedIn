using Newtonsoft.Json.Linq;

namespace Skybrud.Social.LinkedIn.Objects {
    
    /// <summary>
    /// Class representing a basic LinkedIn object derived from an instance of <code>JObject</code>.
    /// </summary>
    public class LinkedInJsonObject {

        #region Properties

        public JObject JObject { get; private set; }

        #endregion

        #region Constructors

        protected LinkedInJsonObject(JObject obj)
        {
            JObject = obj;
        }

        #endregion

    }

}