using Lognation.Infra.CrossCutting.Security;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lognation.Domain.Entities
{
    public class Login : Entity
    {
        #region Fields

        public int LoginId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
                this.SetPassword(value);
            }
        }
        private string _password;

        public byte[] PasswordHash { get; private set; }

        public byte[] PasswordSalt { get; private set; }

        public int UserId { get; set; }
        public User User { get; set; }

        #endregion

        #region Public Methods

        public void ValidateAccess(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            if (this.PasswordHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

            if (this.PasswordSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(this.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != this.PasswordHash[i])
                    {
                        throw new UnauthorizedAccessException("Invalid Password.");
                    };
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetPassword(string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            Hasher.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
        }

        #endregion
    }
}
