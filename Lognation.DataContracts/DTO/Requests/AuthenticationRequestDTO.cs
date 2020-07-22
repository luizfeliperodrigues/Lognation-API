using System.Runtime.Serialization;

namespace Lognation.DataContracts.DTO.Requests
{
    [DataContract]
    public class AuthenticationRequestDTO : IValidator
    {
        [DataMember]
        public string UserNameOrEmail { get; set; }

        [DataMember]
        public string Password { get; set; }

        public bool IsValid() => !string.IsNullOrEmpty(this.UserNameOrEmail) || !string.IsNullOrEmpty(this.Password);
    }
}
