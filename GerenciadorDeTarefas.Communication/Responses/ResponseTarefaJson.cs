using GerenciadorDeTarefas.Communication.Utilitarios;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Communication.Responses;

public class ResponseTarefaJson
{
    public int Id { get; set; }
    public string NomeTarefa { get; set; } = string.Empty;
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly dataLimite { get; set; }
}
