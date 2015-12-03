using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdateShare : LinkedInJsonObject {

        #region Properties

        public string Comment { get; private set; }
        public string Id { get; private set; }
        public LinkedInUpdateShareContent Content { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdateShare(JObject obj) : base(obj) {
            Comment = obj.GetString("comment");
            Id = obj.GetString("id");
            Content = obj.GetObject("content", LinkedInUpdateShareContent.Parse);
        }

        #endregion

        #region Static methods

        public static LinkedInUpdateShare Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdateShare(obj);
        }

        #endregion
    }
}