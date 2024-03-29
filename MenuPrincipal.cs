﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linha
{
    public class MenuBase
    {
        public void ExibirMenu(Dictionary<int, string> opcoesMenu, Dictionary<int, Action> dicionarioMenus)
        {

            foreach (var opcao in opcoesMenu)
            {
                Console.WriteLine($"{opcao.Key}. {opcao.Value}");
            }

            string menuDesejado = Console.ReadLine();

            

            if (int.TryParse(menuDesejado, out int opcaoDesejada) && dicionarioMenus.ContainsKey(opcaoDesejada))
            {
                Console.Clear();
                dicionarioMenus[int.Parse(menuDesejado)].Invoke();
            }

            else
            {
                Console.WriteLine("Digite uma opção válida\n");
            }
        }
    }

    public class MenuPrincipal : MenuBase
    {
        public void OpcoesMenu()
        {
            Console.Clear();
            Console.WriteLine("*****Bem-vindo ao Linha, seu gerenciador de projetos pessoais*****\n");

            Dictionary<int, string> opcoesMenu = new Dictionary<int, string>
            {
                {1, "Usuários" },
                {2, "Tarefas" },
                {3, "Projetos" }
            };

            Dictionary<int, Action> dicionarioMenus = new Dictionary<int, Action>
            {
                {1, () => UsuariosMenu.ExibirUsuariosMenu()},
                {2, () => TarefasMenu.ExibirTarefasMenu() },
                {3, () => ProjetosMenu.ExibirProjetosMenu() }
            };

            ExibirMenu(opcoesMenu, dicionarioMenus);
        }
    }
}
          
    
