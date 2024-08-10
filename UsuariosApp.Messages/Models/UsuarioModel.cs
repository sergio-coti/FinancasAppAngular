using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Messages.Models
{
    /// <summary>
    /// Classe de modelo de dados para deserializar os dados gravados na fila
    /// </summary>
    public class UsuarioModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
    }
}
