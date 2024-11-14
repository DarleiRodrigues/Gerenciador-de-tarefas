namespace GerenciadorDeTarefas.Communication.Utilitarios;

public static class StatusListaOpcoes
{
    public static List<StatusOpcoes> Lista = new List<StatusOpcoes>
    {
        new StatusOpcoes{Id = 3, Nome = "Concluída"},
        new StatusOpcoes{ Id = 2, Nome = "Em andamento" },
        new StatusOpcoes{ Id = 1, Nome = "Aguardando" }
    };
}
