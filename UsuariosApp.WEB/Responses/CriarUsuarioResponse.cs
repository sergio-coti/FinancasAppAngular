namespace UsuariosApp.WEB.Responses
{
    /// <summary>
    /// Modelo de dados para capturar o retorno obtido da API
    /// </summary>
    public class CriarUsuarioResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
    }
}
