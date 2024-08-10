using System.ComponentModel.DataAnnotations;

namespace UsuariosApp.API.Dtos
{
    /// <summary>
    /// DTO para a requisição de autenticação de usuário
    /// </summary>
    public class AutenticarUsuarioRequestDto
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }

        [MinLength(8, ErrorMessage = "Por favor, informe a senha com pelo menos {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe a senha do usuário.")]
        public string? Senha { get; set; }
    }
}
