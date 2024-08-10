using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Logs.Collections
{
    public class LogUsuarios
    {
        public Guid? Id { get; set; }
        public DateTime? DataHora { get; set; }        
        public Operacao? Operacao { get; set; }
        public string? Descricao { get; set; }
        public Guid? UsuarioId{ get; set; }
    }

    public enum Operacao
    {
        Criacao = 1,
        Autenticacao = 2
    }
}
