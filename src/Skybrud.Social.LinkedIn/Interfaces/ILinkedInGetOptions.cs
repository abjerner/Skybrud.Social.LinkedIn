using Skybrud.Social.Interfaces;
using Skybrud.Social.LinkedIn.Fields;

namespace Skybrud.Social.LinkedIn.Interfaces {
    
    public interface ILinkedInGetOptions : IGetOptions {

        LinkedInFieldCollection Fields { get; }

    }

}