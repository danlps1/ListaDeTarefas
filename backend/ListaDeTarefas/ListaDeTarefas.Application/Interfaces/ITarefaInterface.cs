using ListaDeTarefas.Application.Dto.Tarefa;
using ListaDeTarefas.Application.Dto.Usuario;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;

namespace ListaDeTarefas.Application.Interfaces;

public interface ITarefaInterface
{
    public ResponseDto<TarefaModel> CadastrarTarefa(CriarTarefaDto criarTarefaDto);
    
    public ResponseDto<List<TarefaModel>> ListarTarefas();
    
    public ResponseDto<TarefaModel> BuscarTarefaPorId(int tarefaId);
    
    public ResponseDto<TarefaModel> EditarTarefa(EditarTarefaDto editarTarefaDto);
    
    public ResponseDto<TarefaModel> DeletarTarefa(int tarefaId);
}