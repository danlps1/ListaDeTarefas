using System.ComponentModel.DataAnnotations;

namespace ListaDeTarefas.Application.Dto.Usuario;

public class CriarUsuarioDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    [StringLength(100, MinimumLength = 3)]
    public string Nome { get; set; }
}