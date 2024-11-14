using GerenciadorDeTarefas.Communication.Utilitarios;
using System.Text.Json.Serialization;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefa.Modelo;

public class TarefaModelo
{
    public int Id { get; set; }
    public string NomeTarefa { get; set; } = string.Empty;
    public string DescricaoTarefa { get; set; } = string.Empty;
    public string Prioridade { get; set; } = string.Empty;
    [JsonConverter(typeof(DateOnlyJsonConverter))]
    public DateOnly dataLimite { get; set; }
    public string Status { get; set; } = string.Empty;
}
