using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CadastroUsuário.Data;
using WebAPI_CadastroUsuário.Models;

namespace WebAPI_CadastroUsuário.Services
{
    public class UsuarioService: IUsuarioInterface
    {
        //Para conectar ao banco de dados
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> CriarUsuario(Usuario usuarioNovo)
        {
            var usuario = new Usuario()
            {
                Nome = usuarioNovo.Nome,
                Email = usuarioNovo.Email,
                Senha = usuarioNovo.Senha,
                Telefone = usuarioNovo.Telefone
            };

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> DeletarUsuario(int Id)
        {
            var user = await _context.usuario.FindAsync(Id);
            if (user == null) return false;
            _context.Remove(user);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Usuario> EditarUsuario(Usuario usuarioEditado)
        {
            _context.usuario.Update(usuarioEditado);
            await _context.SaveChangesAsync();
            return usuarioEditado;
        }

        public async Task<List<Usuario>> ListarUsuario()
        {
            return await _context.usuario.ToListAsync();
        }


    }
}
