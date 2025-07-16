using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using ListaDeTarefas.Infrastructure.Data;

namespace ListaDeTarefas.Application.Services;

public class UsuarioService : IUsuarioInterface
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context) 
    {
        _context = context;
    }

    public ResponseDto<UsuarioModel> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<List<UsuarioModel>> ListarUsuarios()
    {
        throw new NotImplementedException();
    }

    public ResponseDto<UsuarioModel> BuscarUsuarioPorId(int usuarioId)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<UsuarioModel> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<UsuarioModel> DeletarUsuario(int usuarioId)
    {
        throw new NotImplementedException();
    }
}