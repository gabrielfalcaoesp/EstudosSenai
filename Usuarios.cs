using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linha
{
    public class UsuariosMenu : MenuBase
    {
        public static void ExibirUsuariosMenu()
        {
            Console.WriteLine("Bem-vindo ao menu Usuarios");

            Dictionary<int, string> opcoesMenu = new Dictionary<int, string>
            {
                {1, "Criar usuário" },
                {2, "Editar usuário" },
                {3, "Deletar usuário" },
                {4, "Exibir lista de usuários" },
                {5, "Exibir tarefas do usuário" }
            };

            Dictionary<int, Action> dicionarioMenus = new Dictionary<int, Action>
            {
                {1, () => Usuarios.CriarUsuario()},
                {2, () => Usuarios.EditarUsuario() },
                {3, () => Usuarios.DeletarUsuario() },
                {4, () => Usuarios.ListarUsuarios() },
                {5, () => Usuarios.TarefasUsuario() }
            };

            MenuBase menuUsuarios = new MenuBase();
            menuUsuarios.ExibirMenu(opcoesMenu, dicionarioMenus);
        }   
    }
    public class Usuarios
    {
        
        public static void CriarUsuario()
        {
            Console.WriteLine("Opção criar usuário");
        }
        public static void EditarUsuario()
        {
            Console.WriteLine("Opção editar usuário");
        }
        public static void DeletarUsuario()
        {
            Console.WriteLine("Opção deletar usuário");
        }
        public static void ListarUsuarios()
        {
            Console.WriteLine("Opção listar usuário");
        }
        public static void TarefasUsuario()
        {
            Console.WriteLine("Opção exibir tarefas usuário");
        }

    }
}
