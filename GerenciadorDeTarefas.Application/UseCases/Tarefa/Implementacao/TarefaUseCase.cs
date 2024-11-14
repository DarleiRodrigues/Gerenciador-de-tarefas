using GerenciadorDeTarefas.Application.UseCases.Tarefa.Interface;
using GerenciadorDeTarefas.Application.UseCases.Tarefa.Modelo;
using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Responses;
using GerenciadorDeTarefas.Communication.Utilitarios;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefa.Implementacao;

public class TarefaUseCase : ITarefaUseCase
{
    // Salvar as tarefas
    private readonly List<TarefaModelo> tarefas = new List<TarefaModelo>();

    // Receber e salvar as tarefas
    public ResponseTarefaJson CriarTarefa(RequestTarefaJson requestTarefa)
    {
        // Verificar se o nome da prioridade fornecido existe na lista de prioridades
        var prioridadeValida = PrioridadeListaOpcoes.Lista
            .FirstOrDefault(p => p.Nome.Equals(requestTarefa.Prioridade, StringComparison.OrdinalIgnoreCase));

        if (prioridadeValida == null)
        {
            return null;
        }

        // Verificar se o nome do status fornecido existe na lista de status
        var statusValido = StatusListaOpcoes.Lista
            .FirstOrDefault(p => p.Nome.Equals(requestTarefa.Status, StringComparison.OrdinalIgnoreCase));

        if (statusValido == null)
        {
            return null;
        }

        var novaTarefa = new TarefaModelo
        {
            Id = tarefas.Count + 1,
            NomeTarefa = requestTarefa.NomeTarefa,
            DescricaoTarefa = requestTarefa.DescricaoTarefa,
            dataLimite = requestTarefa.dataLimite,
            Prioridade = requestTarefa.Prioridade,
            Status = requestTarefa.Status
        };

        tarefas.Add(novaTarefa);

        return new ResponseTarefaJson
        {
            Id = novaTarefa.Id,
            NomeTarefa = novaTarefa.NomeTarefa,
            dataLimite = novaTarefa.dataLimite
        };
    }

    // Mostrar tarefa usando ID
    public ResponseTarefaJson GetTarefaById(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return null;

        return new ResponseTarefaJson
        {
            Id = tarefa.Id,
            NomeTarefa = tarefa.NomeTarefa,
            dataLimite = tarefa.dataLimite
        };
    }

    // Mostrar todas as tarefas existentes
    public List<ResponseTarefaJson> GetAllTarefas()
    {
        return tarefas.Select(tarefa => new ResponseTarefaJson
        {
            Id = tarefa.Id,
            NomeTarefa = tarefa.NomeTarefa,
            dataLimite = tarefa.dataLimite
        }).ToList();
    }

    // Atualizar uma tarefa
    public ResponseTarefaJson AtualizarTarefa(int id, RequestTarefaJson requestTarefa)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null) return null;

        tarefa.NomeTarefa = requestTarefa.NomeTarefa;
        tarefa.DescricaoTarefa = requestTarefa.DescricaoTarefa;
        tarefa.Prioridade = requestTarefa.Prioridade;
        tarefa.dataLimite = requestTarefa.dataLimite;
        tarefa.Status = requestTarefa.Status;

        return new ResponseTarefaJson
        {
            Id = tarefa.Id,
            NomeTarefa = tarefa.NomeTarefa,
            dataLimite = tarefa.dataLimite
        };
    }

    // Exluir tarefas
    public bool DeleteTarefa(int id)
    {
        var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
        if(tarefa == null) return false;

        tarefas.Remove(tarefa);
        return true;
    }
}
