using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ListaDeTarefas.Application.Dto.Tarefa;

public class CriarTarefaDto
{
    [Required(ErrorMessage = "O campo tarefa é obrigatório")]
    public string Tarefa { get; set; }

    [Required(ErrorMessage = "O Id do usuário é um campo obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int UsuarioId { get; set; }
}