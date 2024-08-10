namespace UsuariosApp.API.Dtos
{
    /// <summary>
    /// DTO para a resposta de cadastro de usuário
    /// </summary>
    public class CriarUsuarioResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
