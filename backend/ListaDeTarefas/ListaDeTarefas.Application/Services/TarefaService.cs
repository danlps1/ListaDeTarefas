using ListaDeTarefas.Application.Dto.Tarefa;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using ListaDeTarefas.Infrastructure.Data;

namespace ListaDeTarefas.Application.Services;

public class TarefaService : ITarefaInterface
{
    private readonly AppDbContext _context;

    public TarefaService(AppDbContext context)
    {
        _context = context;
    }

    public ResponseDto<TarefaModel> CadastrarTarefa(CriarTarefaDto criarTarefaDto)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<List<TarefaModel>> ListarTarefas()
    {
        throw new NotImplementedException();
    }

    public ResponseDto<TarefaModel> BuscarTarefaPorId(int tarefaId)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<TarefaModel> EditarTarefa(EditarTarefaDto editarTarefaDto)
    {
        throw new NotImplementedException();
    }

    public ResponseDto<TarefaModel> DeletarTarefa(int tarefaId)
    {
        throw new NotImplementedException();
    }
}