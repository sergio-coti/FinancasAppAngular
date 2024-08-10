namespace UsuariosApp.WEB.Responses
{
    /// <summary>
    /// Modelo de dados para capturar o retorno obtido da API
    /// </summary>
    public class AutenticarUsuarioResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
        public DateTime? DataHoraExpiracao { get; set; }
    }
}
