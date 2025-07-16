using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Application.Dto.Tarefa;

public class EditarTarefaDto
{
    [Required(ErrorMessage = "O Id da tarefa é um campo obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo tarefa é obrigatório")]
    public string Tarefa { get; set; }

    public bool Completa { get; set; }
}