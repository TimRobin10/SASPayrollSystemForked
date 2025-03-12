using DomainLayer.Common;
using DomainLayer.Enums;
using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.ChangePasswordRequest
{
    public class ChangePasswordRequestModel : IChangePasswordRequestModel
    {
        private const int saltSize = 32;
        private string _password = string.Empty;

        public ChangePasswordRequestModel()
        {
            var currentDateTime = DateTime.Now;
            DateOfRequest = DateOnly.FromDateTime(currentDateTime);
            TimeOfRequest = TimeOnly.FromDateTime(currentDateTime);
        }

        [Key]
        public Guid Id { get; set; }

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

        [Required]
        [Column(TypeName = "tinyint")]
        public FormStatus Status { get; set; } = FormStatus.Pending;
    }
}
