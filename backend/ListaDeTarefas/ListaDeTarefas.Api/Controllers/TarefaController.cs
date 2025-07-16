using ListaDeTarefas.Application.Dto.Tarefa;
using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeTarefas.Api.Controllers;

[ApiController]
[Route("api/tarefa")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaInterface _tarefaService;

    public TarefaController(ITarefaInterface tarefaInterface)
    {
        _tarefaService = tarefaInterface;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto<TarefaModel>>> CadastrarUsuario(CriarTarefaDto criarTarefaDto)
    {
        return Created("api/tarefa", await _tarefaService.CadastrarTarefa(criarTarefaDto));
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto<List<TarefaModel>>>> ListarUsuarios()
    {
        return Ok(await _tarefaService.ListarTarefas());
    }

    [HttpGet("{tarefaId}")]
    public async Task<ActionResult<ResponseDto<TarefaModel>>> BuscarUsuarioPorId(int tarefaId)
    {
        return Ok(await _tarefaService.BuscarTarefaPorId(tarefaId));
    }

    [HttpPut]
    public async Task<ActionResult<ResponseDto<TarefaModel>>> EditarUsuario(EditarTarefaDto editarTarefaDto)
    {
        return Ok(await _tarefaService.EditarTarefa(editarTarefaDto));
    }

    [HttpDelete("{tarefaId}")]
    public async Task<ActionResult<ResponseDto<TarefaModel>>> DeletarUsuario(int tarefaId)
    {
        return Ok(await _tarefaService.DeletarTarefa(tarefaId));
    }
}