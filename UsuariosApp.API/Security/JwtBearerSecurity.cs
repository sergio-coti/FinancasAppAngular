using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApp.Data.Entities;

namespace UsuariosApp.API.Security
{
    /// <summary>
    /// Classe para configurarmos a geração dos tokens JWT
    /// </summary>
    public class JwtBearerSecurity
    {
        #region Parâmetros para geração do TOKEN

        public static string Secretkey => "FB989B29-4CE2-4E2A-919F-B3B18A7F8574";
        public static int ExpirationInHours => 12;

        #endregion

        /// <summary>
        /// Método para fazermos a geração do TOKEN JWT
        /// </summary>
        public static string GenerateToken(Usuario usuario)
        {
            //capturar a chave para criptografar a assinatura do token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secretkey);

            //criando o conteudo do TOKEN JWT
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //gravar o email do usuário autenticado no token
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, usuario.Email) }),

                //gravar a data e hora de expiração do token
                Expires = DateTime.UtcNow.AddHours(ExpirationInHours),

                //gravar a assinatura (chave secreta) criptografada do token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                        SecurityAlgorithms.HmacSha256Signature)
            };

            //gerando e retornando o token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
