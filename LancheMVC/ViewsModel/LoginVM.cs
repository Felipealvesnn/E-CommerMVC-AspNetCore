using System.ComponentModel.DataAnnotations;

namespace LancheMVC.ViewsModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnURL { get; set; }
    }
}