using System.Runtime.Serialization;

namespace Lognation.DataContracts.DTO.Requests
{
    [DataContract]
    public class SignUpRequestDTO : IValidator
    {
        [DataMember]
        public UserBasicInfoDTO BasicInfo { get; set; }

        [DataMember]
        public UserLoginDTO Login { get; set; }

        public bool IsValid() => this.Login != null
            && this.BasicInfo.IsValid()
            && this.Login.IsValid();
    }
}
