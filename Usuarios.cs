using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public int IdUsuario { get; private set; }
        public string Nome { get; private set; }
        public string Cargo { get; private set; }
        public string Setor { get; private set; }


        public Usuarios (int idUsuario, string nome, string cargo, string setor)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Cargo = cargo;
            Setor = setor;
        }

        
        public static void CriarUsuario()
        {       
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            int proximoId = listaUsuarios.TamanhoLista();
            Console.WriteLine("Digite o nome do usuario que deseja adicionar: ");
            string nomeInserido = Console.ReadLine();
            Console.WriteLine("Digite o cargo do usuario que deseja adicionar: ");
            string cargoInserido = Console.ReadLine();
            Console.WriteLine("Digite o setor do usuario que deseja adicionar: ");
            string setorInserido = Console.ReadLine();

            Usuarios novoUsuario = new Usuarios(proximoId, nomeInserido, cargoInserido, setorInserido);
            
            listaUsuarios.AdicionarUsuario(novoUsuario);
            Console.WriteLine("O usuário foi adicionado!\n");
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
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            listaUsuarios.TamanhoLista();
        }
        public static void TarefasUsuario()
        {
            Console.WriteLine("Opção exibir tarefas usuário");
        }

    }

    public class ListaUsuarios 
    {
        

        public void AdicionarUsuario(Usuarios usuario)
        {
            ListaDeUsuarios.Add(usuario);
        }

        public int TamanhoLista()
        {
            int tamanhoLista = ListaDeUsuarios.Count;
            Console.WriteLine(tamanhoLista);
            return tamanhoLista;
        }

        public void PercorrerLista()
        {
            foreach (var elemento in ListaDeUsuarios)
            {
                Console.WriteLine(elemento.IdUsuario);
                Console.WriteLine(elemento.Nome);
                Console.WriteLine(elemento.Setor);
            }
                
        }

    }
}
