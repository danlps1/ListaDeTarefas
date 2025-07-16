using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;

namespace ListaDeTarefas.Application.Interfaces;

public interface IUsuarioInterface
{
    public Task<ResponseDto<UsuarioModel>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto);
    
    public Task<ResponseDto<List<UsuarioModel>>> ListarUsuarios();
    
    public Task<ResponseDto<UsuarioModel>> BuscarUsuarioPorId(int usuarioId);
    
    public Task<ResponseDto<UsuarioModel>> EditarUsuario(EditarUsuarioDto editarUsuarioDto);
    
    public Task<ResponseDto<UsuarioModel>> DeletarUsuario(int usuarioId);
}