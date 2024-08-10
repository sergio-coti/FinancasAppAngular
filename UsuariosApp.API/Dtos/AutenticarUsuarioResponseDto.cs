namespace UsuariosApp.API.Dtos
{
    /// <summary>
    /// DTO para a resposta de autenticação de usuário
    /// </summary>
    public class AutenticarUsuarioResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
    }
}
