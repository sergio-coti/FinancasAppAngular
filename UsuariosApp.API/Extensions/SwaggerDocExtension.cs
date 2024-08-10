using Microsoft.OpenApi.Models;

namespace UsuariosApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar a documentação do Swagger
    /// </summary>
    public static class SwaggerDocExtension
    {
        /// <summary>
        /// Método para adicionarmos configurações para uso do Swagger na API
        /// </summary>
        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => 
            {
                //Configurando os textos da página do Swagger
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FinancasApp - API para controle de contas a pagar e receber",
                    Description = "Formação Angular - COTI Informática",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "COTI Informática",
                        Email = "contato@cotiinformatica.com.br",
                        Url = new Uri("http://www.cotiinformatica.com.br")
                    }
                });

                //Configurando o tipo de interface de autenticação
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Entre com o token JWT para autenticar o seu usuário",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                //habilitando os testes de autenticação no swagger
                options.AddSecurityRequirement(new OpenApiSecurityRequirement 
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, new string[]{ }
                    }
                });
            });

            return services;
        }
    }
}
