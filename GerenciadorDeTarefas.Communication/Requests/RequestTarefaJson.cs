using GerenciadorDeTarefas.Communication.Utilitarios;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Communication.Requests;

public class RequestTarefaJson
{
    public string NomeTarefa { get; set; } = string.Empty;
    public string DescricaoTarefa { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly dataLimite { get; set; }
    public string Status {  get; set; } = string.Empty;
}
