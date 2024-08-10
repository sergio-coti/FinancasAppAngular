using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Logs.Settings
{
    public class MongoDBSettings
    {
        public static string? Host => "mongodb://localhost:27017/";
        public static string? Database => "DBUsuarios";
    }
}
