using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            var campoDeEdicao = "";
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            Console.Write("Digite o ID do usuário que deseja editar: ");
            int idUsuario = int.Parse(Console.ReadLine());
            Console.Write("Qual campo você deseja editar?" +
                "1. Nome" +
                "2. Cargo" +
                "3. Setor");
            int opcaoDeEdicao = int.Parse(Console.ReadLine());
            switch (opcaoDeEdicao)
            {
                case 1:
                    campoDeEdicao = "Nome";
                    break;

                case 2:
                    campoDeEdicao = "Cargo";
                break;

                case 3:
                    campoDeEdicao = "Setor";
                break;

            }
            
            listaUsuarios.AlterarDadosUsuario(idUsuario, campoDeEdicao);
        }
        public static void DeletarUsuario()
        {
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            Console.Write("Digite o ID do usuário que deseja deletar: ");
            int idUsuario = int.Parse(Console.ReadLine());
            listaUsuarios.RemoverUsuario(idUsuario);
            

        }
        public static void ListarUsuarios()
        {
            ListaUsuarios listaUsuarios = new ListaUsuarios();
            listaUsuarios.PercorrerLista();
        }
        public static void TarefasUsuario()
        {
            Console.WriteLine("Opção exibir tarefas usuário");
        }

    }

    public class ListaUsuarios 
    {

        private static List<Usuarios> ListaDeUsuarios = new List<Usuarios>();
        public void AdicionarUsuario(Usuarios usuario)
        {
            ListaDeUsuarios.Add(usuario);
        }

        public void RemoverUsuario(int usuario)
        {
            if(ListaDeUsuarios.Exists(u => u.IdUsuario == usuario))
            {
                Usuarios usuarioDeletado = ListaDeUsuarios[usuario];
                Console.Write($"Tem certeza que deseja deletar o usuário {usuarioDeletado.Nome} ?(s/n): ");
                string confirmacao = Console.ReadLine();
                if (confirmacao == "s")
                {
                    ListaDeUsuarios.Remove(usuarioDeletado);
                    Console.WriteLine("Usuario foi deletado");
                    Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu principal");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("O ID informado não existe na listagem de usuários, por favor verifique o ID correto");
                Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu principal");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
            }
            
        }

        public int TamanhoLista()
        {
            int tamanhoLista = ListaDeUsuarios.Count;
            return tamanhoLista;
        }

        public void PercorrerLista()
        {
            foreach (var elemento in ListaDeUsuarios)
            {
                Console.WriteLine($"{elemento.IdUsuario} | {elemento.Nome} | {elemento.Cargo} | {elemento.Setor}");
            }

            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu principal");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            
                
        }

        public void AlterarDadosUsuario(int idUsuario, string campoDeEdicao)
        {
            Usuarios usuario = ListaDeUsuarios[idUsuario];
            object valor = ObterValorDaPropriedade(usuario, campoDeEdicao);
            Console.Write($"Insira a alteração que você deseja fazer no campo {campoDeEdicao} do usuario {usuario}: ");
            string valorInserido = Console.ReadLine();
            Console.Write($"O campo {valor} será alterado para {valorInserido}. Deseja confirmar a alteração? (s/n): ");

        }

        static object ObterValorDaPropriedade(object objeto, string nomeDaPropriedade)
        {
            PropertyInfo propriedade = objeto.GetType().GetProperty(nomeDaPropriedade);
                object valor = propriedade.GetValue(objeto);
                return valor;

        }

    }
}
