using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;

namespace ListaDeTarefas.Application.Interfaces;

public interface IUsuarioInterface
{
    public ResponseDto<UsuarioModel> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto);
    
    public ResponseDto<List<UsuarioModel>> ListarUsuarios();
    
    public ResponseDto<UsuarioModel> BuscarUsuarioPorId(int usuarioId);
    
    public ResponseDto<UsuarioModel> EditarUsuario(EditarUsuarioDto editarUsuarioDto);
    
    public ResponseDto<UsuarioModel> DeletarUsuario(int usuarioId);
}