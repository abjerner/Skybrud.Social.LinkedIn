using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.LinkedIn.Objects.Updates
{
    public class LinkedInUpdateShareContent : LinkedInJsonObject {
        
        #region Properties

        public string Description { get; private set; }
        public string EyebrowUrl { get; private set; }
        public string ShortenedUrl { get; private set; }
        public string SubmittedImageUrl { get; private set; }
        public string SubmittedUrl { get; private set; }
        public string Title { get; private set; }
        public string ThumbnailUrl { get; private set; }
        public DateTime Timestamp { get; private set; }

        #endregion

        #region Constructors

        private LinkedInUpdateShareContent(JObject obj) : base(obj) {
            Double timeStamp = obj.GetDouble("timestamp");

            Description = obj.GetString("description");
            EyebrowUrl = obj.GetString("eyebrowUrl");
            ShortenedUrl = obj.GetString("shortenedUrl");
            SubmittedImageUrl = obj.GetString("submittedImageUrl");
            SubmittedUrl = obj.GetString("submittedUrl");
            Title = obj.GetString("title");
            ThumbnailUrl = obj.GetString("thumbnailUrl");
            Timestamp = SocialUtils.GetDateTimeFromUnixTime(timeStamp / 1000);
        }

        #endregion

        #region Static methods

        public static LinkedInUpdateShareContent Parse(JObject obj) {
            return obj == null ? null : new LinkedInUpdateShareContent(obj);
        }

        #endregion
    }
}