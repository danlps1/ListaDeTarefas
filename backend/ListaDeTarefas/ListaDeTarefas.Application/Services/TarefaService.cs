using Azure;
using ListaDeTarefas.Application.Dto.Tarefa;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Application.Utils;
using ListaDeTarefas.Domin.Dto;
using ListaDeTarefas.Domin.Entities;
using ListaDeTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ListaDeTarefas.Application.Services;

public class TarefaService : ITarefaInterface
{
    private readonly AppDbContext _context;
    private readonly IUsuarioInterface _usuarioService;

    public TarefaService(AppDbContext context, IUsuarioInterface usuarioInterface)
    {
        _context = context;
        _usuarioService = usuarioInterface;
    }

    public async Task<ResponseDto<TarefaModel>> CadastrarTarefa(CriarTarefaDto criarTarefaDto)
    {
        ResponseDto<TarefaModel> response = new ResponseDto<TarefaModel>();

        try
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(criarTarefaDto.UsuarioId);
            if (usuario.Dados == null)
            {
                response.Mensagem = usuario.Mensagem;
                return response;
            }

            var novaTarefa = new TarefaModel()
            {
                Tarefa = criarTarefaDto.Tarefa,
                UsuarioId = usuario.Dados.Id,
                Completa = false
            };

            _context.Tarefas.Add(novaTarefa);
            await _context.SaveChangesAsync();

            response.Dados = novaTarefa;
            response.Mensagem = MensagemTarefa.TarefaCasdastrada;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<List<TarefaModel>>> ListarTarefas()
    {
        ResponseDto<List<TarefaModel>> response = new ResponseDto<List<TarefaModel>>();

        try
        {
            var tarefas = await _context.Tarefas
                .Include(t => t.Usuario)
                .ToListAsync();

            response.Dados = tarefas;
            response.Mensagem = MensagemTarefa.TarefasEncontradas;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<TarefaModel>> BuscarTarefaPorId(int tarefaId)
    {
        ResponseDto<TarefaModel> response = new ResponseDto<TarefaModel>();

        try
        {
            var tarefa = await _context.Tarefas
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(t => t.Id == tarefaId);

            if (tarefa == null)
            {
                response.Mensagem = MensagemTarefa.TarefaNaoEncontrada;
                return response;
            }

            response.Dados = tarefa;
            response.Mensagem = MensagemTarefa.TarefaEncontrada;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<TarefaModel>> EditarTarefa(EditarTarefaDto editarTarefaDto)
    {
        ResponseDto<TarefaModel> response = new ResponseDto<TarefaModel>();

        try
        {
            var tarefa = await BuscarTarefaPorId(editarTarefaDto.Id);

            if (tarefa.Dados == null)
            {
                response.Mensagem = tarefa.Mensagem;
                return response;
            }

            tarefa.Dados.Tarefa = editarTarefaDto.Tarefa;
            tarefa.Dados.Completa = editarTarefaDto.Completa;

            _context.Tarefas.Update(tarefa.Dados);
            await _context.SaveChangesAsync();

            response.Dados = tarefa.Dados;
            response.Mensagem = MensagemTarefa.TarefaEditada;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }

    public async Task<ResponseDto<TarefaModel>> DeletarTarefa(int tarefaId)
    {
        ResponseDto<TarefaModel> response = new ResponseDto<TarefaModel>();

        try
        {
            var tarefa = await BuscarTarefaPorId(tarefaId);

            if (tarefa.Dados == null)
            {
                response.Mensagem = tarefa.Mensagem;
                return response;
            }

            _context.Tarefas.Remove(tarefa.Dados);
            await _context.SaveChangesAsync();

            response.Dados = null;
            response.Mensagem = MensagemTarefa.TarefaExcluida;
            return response;
        }
        catch (Exception e)
        {
            response.Mensagem = e.Message;
            return response;
        }
    }
}