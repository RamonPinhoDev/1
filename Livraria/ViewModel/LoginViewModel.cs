using System.ComponentModel.DataAnnotations;

namespace Livraria.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Informe o nome")]
        [Display(Name ="Usuário")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        public string Password { get; set; }

        //enviar automaticamente o usuário de volta à página
        //aonde ele estava tentando acessar antes de ser autenticado.
        public string? ReturnUrl { get; set; }



    }
}
