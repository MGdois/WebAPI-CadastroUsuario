using Microsoft.AspNetCore.Mvc;
using WebAPI_CadastroUsuário.Models;

namespace WebAPI_CadastroUsuário.Services
{
    public interface IUsuarioInterface
    {
        Task<List<Usuario>> ListarUsuario();
        Task<Usuario> CriarUsuario(Usuario usuarioNovo);
        Task<Usuario> EditarUsuario(Usuario usuarioNovo);
        Task<bool> DeletarUsuario(int Id);

    }
}
