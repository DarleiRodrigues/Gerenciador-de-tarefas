using GerenciadorDeTarefas.Application.UseCases.Tarefa.Interface;
using GerenciadorDeTarefas.Communication.Requests;
using GerenciadorDeTarefas.Communication.Responses;
using GerenciadorDeTarefas.Communication.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GerenciadorDeTarefasController : ControllerBase
{
    private readonly ITarefaUseCase tarefaUseCase;
    public GerenciadorDeTarefasController(ITarefaUseCase tarefa)
    {
        tarefaUseCase = tarefa;
    }

    // Cria uma nova tarefa
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CriarTarefa([FromBody] RequestTarefaJson requestTarefa)
    {
        var response = tarefaUseCase.CriarTarefa(requestTarefa);
        if (response == null)
        {
            // Formata as opções válidas de prioridade e status para exibir na mensagem
            var opcoesPrioridade = string.Join(", ", PrioridadeListaOpcoes.Lista.Select(p => p.Nome));
            var opcoesStatus = string.Join(", ", StatusListaOpcoes.Lista.Select(s => s.Nome));

            // Retorna uma mensagem com as opções disponíveis
            return BadRequest($"Prioridade ou Status inválido. As opções de Prioridade disponíveis são: {opcoesPrioridade}. " +
                              $"As opções de Status disponíveis são: {opcoesStatus}.");
        }
        return Created("", response);
    }

    // Ver tarefa usando Id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTarefaById(int id)
    {
        var response = tarefaUseCase.GetTarefaById(id);
        if (response == null) return NotFound();
        return Ok(response);
    }

    // Mostrar todas as tarefas
    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseTarefaJson>), StatusCodes.Status200OK)]
    public IActionResult GetAllTarefas()
    {
        var response = tarefaUseCase.GetAllTarefas();
        return Ok(response);
    }

    // Atualizar uma tarefa
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseTarefaJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AtualizarTarefa(int id, [FromBody] RequestTarefaJson requestTarefa)
    {
        var response = tarefaUseCase.AtualizarTarefa(id, requestTarefa);
        if (response == null) return NotFound("Tarefa não encontrada.");
        return Ok(response);
    }

    // Excluir uma tarefa
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTarefa(int id)
    {
        var sucesso = tarefaUseCase.DeleteTarefa(id);
        if (!sucesso) return NotFound("Tarefa não encontrada.");
        return NoContent();
    }
}
