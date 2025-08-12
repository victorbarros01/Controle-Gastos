using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models {
    [Table("User")]
    public class User {

        [Key]
        public int UserId { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "O nome de usuário precisa ter no mínimo 3 digitos"), MaxLength(20, ErrorMessage = "O nome de usuário pode ter no máximo 20 digitos")]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "A senha precisar ter no mínimo 8 digitos")]
        public string Password { get; set; }

        //UserPrefsJson
        [Column(TypeName = "nvarchar(max)")]
        public string UserPrefsJson { get; set; } = "{ 'theme':'default', 'notifications':false }";

        //Verification Code
        public int Code { get; set; }

        //Token       
        public string? Token { get; set; }
        public DateTime? TokenExpireIn { get; set; }

        public User() { }

        public User(string username, string email, string password) {
            Username = username;
            Email = email;
            Password = password;
            Code = new Random().Next(1000, 9999);
        }
    }
}
