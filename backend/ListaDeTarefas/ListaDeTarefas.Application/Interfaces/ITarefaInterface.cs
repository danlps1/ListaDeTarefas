using ListaDeTarefas.Application.Dto.Tarefa;
using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;

namespace ListaDeTarefas.Application.Interfaces;

public interface ITarefaInterface
{
    public Task<ResponseDto<TarefaModel>> CadastrarTarefa(CriarTarefaDto criarTarefaDto);
    
    public Task<ResponseDto<List<TarefaModel>>> ListarTarefas();
    
    public Task<ResponseDto<TarefaModel>> BuscarTarefaPorId(int tarefaId);
    
    public Task<ResponseDto<TarefaModel>> EditarTarefa(EditarTarefaDto editarTarefaDto);
    
    public Task<ResponseDto<TarefaModel>> DeletarTarefa(int tarefaId);
}