using System.Runtime.Serialization;

namespace Lognation.DataContracts.DTO.Responses
{
    [DataContract]
    public class AuthenticationResponseDTO
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}
