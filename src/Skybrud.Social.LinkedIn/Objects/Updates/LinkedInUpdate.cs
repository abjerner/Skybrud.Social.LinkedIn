using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdate : LinkedInJsonObject {

        #region Properties

        public bool IsCommentable { get; private set; }
        public bool IsLikable { get; private set; }
        public bool IsLiked { get; private set; }
        public int NumLikes { get; private set; }
        public DateTime Timestamp { get; private set; }
        public LinkedInUpdateCompanyContent UpdateContent { get; private set; }
        public string UpdateKey { get; private set; }
        public string UpdateType { get; private set; }

        #endregion
        
        #region Constructors

        private LinkedInUpdate(JObject obj) : base(obj)
        {
            Double timeStamp = obj.GetDouble("timestamp");

            IsCommentable = obj.GetBoolean("isCommentable");
            IsLikable = obj.GetBoolean("isLikable");
            IsLiked = obj.GetBoolean("isLiked");
            NumLikes = obj.GetInt32("numLikes");
            Timestamp = SocialUtils.GetDateTimeFromUnixTime(timeStamp/1000);
            UpdateContent = obj.GetObject("updateContent", LinkedInUpdateCompanyContent.Parse);
            UpdateKey = obj.GetString("updateKey");
            UpdateType = obj.GetString("updateType");
        }

        #endregion
        
        #region Static methods

        public static LinkedInUpdate Parse(JObject obj)
        {
            return obj == null ? null : new LinkedInUpdate(obj);
        }

        #endregion
    }
}