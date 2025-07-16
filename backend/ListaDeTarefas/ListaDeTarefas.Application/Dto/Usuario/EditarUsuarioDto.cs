using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Application.Dto.Usuario;

public class EditarUsuarioDto
{
    [Required(ErrorMessage = "O Id do usuário é um campo obrigatório")]
    [Range(1, Int32.MaxValue)]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [StringLength(100, MinimumLength = 3)]
    public string Nome { get; set; }
}

