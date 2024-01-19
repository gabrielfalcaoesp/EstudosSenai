using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linha
{
    public class ProjetosMenu : MenuBase
    {
        public static void ExibirProjetosMenu()
        {
            Console.WriteLine("Bem-vindo ao menu Projetos");

            Dictionary<int, string> opcoesMenu = new Dictionary<int, string>
            {
                {1, "Criar projeto" },
                {2, "Editar projeto" },
                {3, "Deletar projeto" },
                {4, "Listar projeto"},

            };

            Dictionary<int, Action> dicionarioMenus = new Dictionary<int, Action>
            {
                {1, () => Projetos.CriarProjeto()},
                {2, () => Projetos.EditarProjeto() },
                {3, () => Projetos.DeletarProjeto() },
                {4, () => Projetos.ListarProjeto() },
            };

            MenuBase menuUsuarios = new MenuBase();
            menuUsuarios.ExibirMenu(opcoesMenu, dicionarioMenus);
        }
    }

        public class Projetos
        {

            public static void CriarProjeto()
            {
                Console.WriteLine("Opção criar projeto");
            }
            public static void EditarProjeto()
            {
                Console.WriteLine("Opção editar projeto");
            }
            public static void DeletarProjeto()
            {
                Console.WriteLine("Opção deletar projeto");
            }
            public static void ListarProjeto()
            {
                Console.WriteLine("Opção listar projeto");
            }

        }  
}

