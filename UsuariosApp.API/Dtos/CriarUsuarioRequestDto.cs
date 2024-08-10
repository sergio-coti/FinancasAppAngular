using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.API.Dtos
{
    /// <summary>
    /// DTO para a requisição de cadastro de usuário
    /// </summary>
    public class CriarUsuarioRequestDto
    {
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(100, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do usuário.")]
        public string? Nome { get; set; }

        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Por favor, informe a senha letras maiúsculas, minúsculas, números, símbolos e pelo menos 8 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}
