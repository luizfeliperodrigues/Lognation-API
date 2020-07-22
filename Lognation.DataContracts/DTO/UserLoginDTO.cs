using System.Runtime.Serialization;

namespace Lognation.DataContracts.DTO
{
    [DataContract]
    public class UserLoginDTO : IValidator
    {
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        public bool IsValid() => (!string.IsNullOrEmpty(this.Email)
                            && !string.IsNullOrEmpty(this.UserName))
                            || !string.IsNullOrEmpty(this.Password);
    }
}
