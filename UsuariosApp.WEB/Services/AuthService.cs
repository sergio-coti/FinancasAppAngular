using Blazored.LocalStorage;
using UsuariosApp.WEB.Responses;

namespace UsuariosApp.WEB.Services
{
    /// <summary>
    /// Classe para serviços que deverão manipular a local storage
    /// </summary>
    public class AuthService
    {
        private readonly ILocalStorageService? _localStorageService;

        public AuthService(ILocalStorageService? localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Método para gravar os dados do usuário autenticado na LocalStorage
        /// </summary>
        public async Task SignIn(AutenticarUsuarioResponse response)
        {
            await _localStorageService.SetItemAsync("auth", response);
        }

        /// <summary>
        /// Método para apagar os dados do usuário gravado na local storage
        /// </summary>
        public async Task SignOut()
        {
            await _localStorageService.RemoveItemAsync("auth");
        }

        /// <summary>
        /// Método para retornar os dados do usuário gravado na local storage
        /// </summary>
        public async Task<AutenticarUsuarioResponse?> GetData()
        {
            //capturar os dados gravados na local storage
            var response = await _localStorageService.GetItemAsync<AutenticarUsuarioResponse>("auth");

            //verificar se o token já expirou
            if(response == null || response.DataHoraExpiracao < DateTime.Now)
            {
                //apagar os dados da local storage
                await SignOut();
                //retornar valor vazio
                return null;
            }
            else
            {
                return response;
            }            
        }
    }
}
