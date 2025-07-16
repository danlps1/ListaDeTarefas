using System.Text.Json.Serialization;

namespace ListaDeTarefas.Domin.Entities;

public class UsuarioModel
{
    public int Id { get; set; }

    public string Nome { get; set; }

    [JsonIgnore] public ICollection<TarefaModel> Tarefas { get; set; }
}