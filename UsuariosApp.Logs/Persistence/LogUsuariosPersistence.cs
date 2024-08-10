using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Logs.Collections;
using UsuariosApp.Logs.Contexts;

namespace UsuariosApp.Logs.Persistence
{
    public class LogUsuariosPersistence
    {
        //atributos
        private MongoDBContext mongoContext = new MongoDBContext();

        /// <summary>
        /// Método para gravação dos logs de usuário no MongoDB
        /// </summary>
        public void Add(LogUsuarios logUsuarios)
            => mongoContext.LogUsuarios.InsertOne(logUsuarios);
    }
}
