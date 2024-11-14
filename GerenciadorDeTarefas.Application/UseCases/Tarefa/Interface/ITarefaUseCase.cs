using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Responses;

namespace GerenciadorDeTarefas.Application.UseCases.Tarefa.Interface;

public interface ITarefaUseCase
{
    ResponseTarefaJson CriarTarefa(RequestTarefaJson requestTarefa);
    ResponseTarefaJson GetTarefaById(int id);
    List<ResponseTarefaJson> GetAllTarefas();
    ResponseTarefaJson AtualizarTarefa(int id, RequestTarefaJson requestTarefa);
    bool DeleteTarefa(int id);
}
