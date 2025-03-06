using DomainLayer.Models.Role;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.User
{
    public class UserModel : IUserModel
    {
        private const int saltSize = 32;

        private string _password = string.Empty;

        [Key]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Username must be 2 - 20 characters only")]
        public string UserName { get; set; } = null!;

        [NotMapped]
        public string Password
        {
            private get
            {
                return _password;
            }
            set
            {
                _password = value;
                Salt = GenerateSalt(saltSize);
                var passwordBytes = Encoding.UTF8.GetBytes(Password);
                var encryptedPasswordBytes = EncryptSha256(passwordBytes);
                var saltedPassword = Salt.Concat(encryptedPasswordBytes).ToArray();
                PasswordHash = EncryptSha256(saltedPassword);
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Salt is empty")]
        [Column(TypeName = "binary(32)")]
        public byte[] Salt { get; private set; } = [];

        [Required(ErrorMessage = "Password Hash is empty")]
        [Column(TypeName = "binary(32)")]
        public byte[] PasswordHash { get; private set; } = [];

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Must be a valid email address")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\+639\d{9}")]
        [StringLength(13, MinimumLength = 12, ErrorMessage = "Must be exactly 12 characters")]
        public string PhoneNumber { get; set; } = null!;

        [Url(ErrorMessage = "Must be a valid Url")]
        public string? Url { get; set; }

        public virtual ICollection<RoleModel> Roles { get; } = [];


        private byte[] GenerateSalt(int size)
        {
            byte[] saltBytes = new byte[size];

            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(saltBytes);
            }

            return saltBytes;
        }

        private byte[] EncryptSha256(byte[] input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(input);
            }
        }
    }
}
