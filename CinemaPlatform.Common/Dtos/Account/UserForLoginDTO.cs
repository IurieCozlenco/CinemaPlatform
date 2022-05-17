using System.ComponentModel.DataAnnotations;

namespace CinemaPlatform.Common.Dtos.Account
{
    public class UserForLoginDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
