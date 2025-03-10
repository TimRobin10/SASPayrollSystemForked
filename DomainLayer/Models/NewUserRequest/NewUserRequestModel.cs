using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.NewUserRequest
{
    public class NewUserRequestModel : INewUserRequestModel
    {
        private string _password = string.Empty;
        private const int saltSize = 32;
        private readonly DateTime _currentDateTime;

        public NewUserRequestModel()
        {
            _currentDateTime = DateTime.Now;
            DateOfRequest = DateOnly.FromDateTime(_currentDateTime);
            TimeOfRequest = TimeOnly.FromDateTime(_currentDateTime);
        }

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
                var encryption = new Encryption();
                _password = value;
                Salt = encryption.GenerateSalt(saltSize);
                PasswordHash = encryption.GenerateHash(Password, Salt);
            }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Salt is empty")]
        [Column(TypeName = "binary(32)")]
        public byte[] Salt { get; private set; } = [];

        [Required(ErrorMessage = "Password Hash is empty")]
        [Column(TypeName = "binary(32)")]
        public byte[] PasswordHash { get; private set; } = [];

        [Required]
        [Column(TypeName = "date")]
        public DateOnly DateOfRequest { get; private set; }

        [Required]
        [Column(TypeName = "time")]
        public TimeOnly TimeOfRequest { get; private set; }
    }
}
