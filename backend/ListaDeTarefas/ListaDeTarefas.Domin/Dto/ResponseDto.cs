namespace ListaDeTarefas.Domin.Dto;

public class ResponseDto<T>
{
    public T? Dados { get; set; }
    public string Mensagem { get; set; }
}