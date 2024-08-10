using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UsuariosApp.API.Dtos;
using UsuariosApp.API.Security;
using UsuariosApp.Data.Contexts;
using UsuariosApp.Data.Entities;
using UsuariosApp.Data.Helpers;
using UsuariosApp.Logs.Collections;
using UsuariosApp.Logs.Persistence;
using UsuariosApp.Messages.Producers;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost("criar")]
        public IActionResult Criar(CriarUsuarioRequestDto request)
        {
            using (var dataContext = new DataContext())
            {
                //verificar se já existe um usuário cadastrado com o email informado
                if (dataContext.Usuarios.FirstOrDefault(u => u.Email.Equals(request.Email)) != null)
                    return StatusCode(400, new { message = "O email informado já está cadastrado. Tente outro." });

                //preenchendo os dados do usuário
                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = SHA256CryptoHelper.ComputeHash(request.Senha)
                };

                //cadastrando o usuário no banco de dados
                dataContext.Usuarios.Add(usuario);
                dataContext.SaveChanges();

                //retornando resposta de sucesso
                return StatusCode(201, new CriarUsuarioResponseDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraCadastro = DateTime.Now
                });
            }
        }

        [HttpPost("autenticar")]
        public IActionResult Autenticar(AutenticarUsuarioRequestDto request)
        {
            using (var dataContext = new DataContext())
            {
                //pesquisar o usuário no banco de dados através do email e da senha
                var usuario = dataContext.Usuarios.FirstOrDefault(u => u.Email.Equals(request.Email)
                                                                    && u.Senha.Equals(SHA256CryptoHelper.ComputeHash(request.Senha)));
                //verificando se o usuário não foi encontrado
                if (usuario == null)
                    //retornando erro de acesso não autorizado (401 - UNAUTHORIZED)
                    return StatusCode(401, new { message = "Acesso negado. Usuário inválido." });

                //retornando os dados do usuário
                return StatusCode(200, new AutenticarUsuarioResponseDto
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraAcesso = DateTime.Now,
                    AccessToken = JwtBearerSecurity.GenerateToken(usuario),
                    DataHoraExpiracao = DateTime.Now.AddHours(JwtBearerSecurity.ExpirationInHours)
                });
            }
        }

        [Authorize]
        [HttpGet("obter-dados")]
        public IActionResult ObterDados()
        {
            //capturar a identificação do usuário gravado no TOKEN
            var email = User.Identity.Name;

            //consultar os dados do usuário
            using (var dataContext = new DataContext())
            {
                var usuario = dataContext.Usuarios
                    .FirstOrDefault(u => u.Email.Equals(email));

                //retornar os dados do usuário
                return StatusCode(200, new 
                { 
                    usuario.Id,
                    usuario.Nome,
                    usuario.Email
                });
            }   
        }
    }
}
