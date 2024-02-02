using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linha
{
    public class TarefasMenu : MenuBase
    {
        public static void ExibirTarefasMenu()
        {
            Console.WriteLine("Bem-vindo ao menu Tarefas");

            Dictionary<int, string> opcoesMenu = new Dictionary<int, string>
            {
                {1, "Criar tarefa" },
                {2, "Editar tarefa" },
                {3, "Deletar tarefa" },
                {4, "Listar tarefas"},

            };

            Dictionary<int, Action> dicionarioMenus = new Dictionary<int, Action>
            {
                {1, () => Tarefas.CriarTarefa()},
                {2, () => Tarefas.EditarTarefa() },
                {3, () => Tarefas.DeletarTarefa() },
                {4, () => Tarefas.ListarTarefas() },
            };

            MenuBase menuUsuarios = new MenuBase();
            menuUsuarios.ExibirMenu(opcoesMenu, dicionarioMenus);
        }
    }
    public class Tarefas
    {

        public static void CriarTarefa()
        {
            Console.WriteLine("Opção criar tarefa");
        }
        public static void EditarTarefa()
        {
            Console.WriteLine("Opção editar tarefa");
        }
        public static void DeletarTarefa()
        {
            Console.WriteLine("Opção deletar tarefa");
        }
        public static void ListarTarefas()
        {
            Console.WriteLine("Opção listar tarefas");
        }

    }
}

