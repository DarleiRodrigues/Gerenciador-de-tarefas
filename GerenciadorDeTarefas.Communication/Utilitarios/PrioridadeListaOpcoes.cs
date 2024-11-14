namespace GerenciadorDeTarefas.Communication.Utilitarios;

public static class PrioridadeListaOpcoes
{
    public static List<OpcoesPrioridade> Lista = new List<OpcoesPrioridade>
    {
        new OpcoesPrioridade { Id = 1, Nome = "Baixa" },
        new OpcoesPrioridade { Id = 2, Nome = "Média" },
        new OpcoesPrioridade { Id = 3, Nome = "Alta" }
    };
}
