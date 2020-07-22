using System.Runtime.Serialization;

namespace Lognation.DataContracts.DTO
{
    [DataContract]
    public class UserBasicInfoDTO : IValidator
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(this.FirstName) && !string.IsNullOrEmpty(this.LastName);
    }
}
