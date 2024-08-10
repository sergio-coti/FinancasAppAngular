using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.WEB.ViewModels
{
    /// <summary>
    /// Modelo de dados para o formulário de cadastro de usuário
    /// </summary>
    public class CriarUsuarioViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o seu nome.")]
        [MinLength(8, ErrorMessage = "Por favor, informe pelo menos {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o seu email.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a sua senha.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Por favor, informe a sua senha com letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a sua senha.")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem, por favor verifique.")]
        public string? SenhaConfirmacao { get; set; }
    }
}
