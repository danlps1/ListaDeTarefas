using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Application.Utils;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using ListaDeTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Application.Services;

public class UsuarioService : IUsuarioInterface
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseDto<UsuarioModel>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto)
    {
        ResponseDto<UsuarioModel> response = new ResponseDto<UsuarioModel>();

        try
        {
            var novoUsuario = new UsuarioModel()
            {
                Nome = criarUsuarioDto.Nome
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            response.Dados = novoUsuario;
            response.Mensagem = MensagemUsuario.UsuarioCasdastrado;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<List<UsuarioModel>>> ListarUsuarios()
    {
        ResponseDto<List<UsuarioModel>> response = new ResponseDto<List<UsuarioModel>>();

        try
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            response.Dados = usuarios;
            response.Mensagem = MensagemUsuario.UsuariosEncontrados;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<UsuarioModel>> BuscarUsuarioPorId(int usuarioId)
    {
        ResponseDto<UsuarioModel> response = new ResponseDto<UsuarioModel>();

        try
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
            {
                response.Mensagem = MensagemUsuario.UsuarioNaoEncontrado;
                return response;
            }

            response.Dados = usuario;
            response.Mensagem = MensagemUsuario.UsuarioEncontrado;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<UsuarioModel>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
    {
        ResponseDto<UsuarioModel> response = new ResponseDto<UsuarioModel>();

        try
        {
            var usuario = await BuscarUsuarioPorId(editarUsuarioDto.Id);

            if (usuario.Dados == null)
            {
                response.Mensagem = MensagemUsuario.UsuarioNaoEncontrado;
                return response;
            }

            usuario.Dados.Nome = editarUsuarioDto.Nome;
            _context.Usuarios.Update(usuario.Dados);
            await _context.SaveChangesAsync();

            response.Dados = usuario.Dados;
            response.Mensagem = MensagemUsuario.UsuarioEditado;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<UsuarioModel>> DeletarUsuario(int usuarioId)
    {
        ResponseDto<UsuarioModel> response = new ResponseDto<UsuarioModel>();

        try
        {
            var usuario = await BuscarUsuarioPorId(usuarioId);

            if (usuario.Dados == null)
            {
                response.Mensagem = MensagemUsuario.UsuarioNaoEncontrado;
                return response;
            }

            _context.Usuarios.Remove(usuario.Dados);
            await _context.SaveChangesAsync();

            response.Dados = usuario.Dados;
            response.Mensagem = MensagemUsuario.UsuarioExcluido;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }
}