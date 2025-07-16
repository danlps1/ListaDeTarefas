namespace ListaDeTarefas.Domin.Entities;

public class TarefaModel
{
    public int Id { get; set; }

    public string Tarefa { get; set; }

    public bool Completa { get; set; }

    public int UsuarioId { get; set; }
    public UsuarioModel Usuario { get; set; }
}