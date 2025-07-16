using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Api.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioInterface _usuarioService;

    public UsuarioController(IUsuarioInterface usuarioInterface)
    {
        _usuarioService = usuarioInterface;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto<UsuarioModel>>> CadastrarUsuario(CriarUsuarioDto criarUsuarioDto)
    {
        return Created("api/usuario", await _usuarioService.CadastrarUsuario(criarUsuarioDto));
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto<List<UsuarioModel>>>> ListarUsuarios()
    {
        return Ok(await _usuarioService.ListarUsuarios());
    }

    [HttpGet("{usuarioId}")]
    public async Task<ActionResult<ResponseDto<UsuarioModel>>> BuscarUsuarioPorId(int usuarioId)
    {
        return Ok(await _usuarioService.BuscarUsuarioPorId(usuarioId));
    }

    [HttpPut]
    public async Task<ActionResult<ResponseDto<UsuarioModel>>> EditarUsuario(EditarUsuarioDto editarUsuarioDto)
    {
        return Ok(await _usuarioService.EditarUsuario(editarUsuarioDto));
    }

    [HttpDelete("{usuarioId}")]
    public async Task<ActionResult<ResponseDto<UsuarioModel>>> DeletarUsuario(int usuarioId)
    {
        return Ok(await _usuarioService.DeletarUsuario(usuarioId));
    }
}