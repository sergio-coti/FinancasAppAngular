using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Data.Entities;
using UsuariosApp.Data.Mappings;

namespace UsuariosApp.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para acesso ao banco de dados
    /// </summary> 
    public class DataContext : DbContext
    {
        /// <summary>
        /// Configurando o tipo de conexão de banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:bdcoti.database.windows.net,1433;Initial Catalog=BDProdutosApp;User ID=usuariocoti;Password=Coti2024!;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        /// <summary>
        /// Disponibilizar os métodos para acesso a entidade usuário no banco de memória
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
