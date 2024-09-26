using System;
using System.Collections.Generic;
using TDE;

namespace TDE
{
    class Program
    {
        // Lista para armazenar as tarefas
        static List<Tarefa> tarefas = new List<Tarefa>();

        static void Main(string[] args)
        {
            while (true)
            {
                ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarTarefa();
                        break;
                    case "2":
                        ListarTarefas();
                        break;
                    case "3":
                        MarcarTarefaConcluida();
                        break;
                    case "4":
                        ExcluirTarefa();
                        break;
                    case "5":
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
            }
        }

        // Método para exibir o menu
        static void ExibirMenu()
        {
            Console.WriteLine("\n=== Menu do Gestor de Tarefas ===");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Listar tarefas");
            Console.WriteLine("3. Marcar tarefa como concluída");
            Console.WriteLine("4. Excluir tarefa");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
        }

        // Método para adicionar uma tarefa
        static void AdicionarTarefa()
        {
            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Tarefa novaTarefa = new Tarefa(titulo);
            tarefas.Add(novaTarefa);

            Console.WriteLine("Tarefa adicionada com sucesso!");
        }

        // Método para listar todas as tarefas
        static void ListarTarefas()
        {
            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa cadastrada.");
                return;
            }

            Console.WriteLine("\n=== Lista de Tarefas ===");
            for (int i = 0; i < tarefas.Count; i++)
            {
                var tarefa = tarefas[i];
                string status = tarefa.Concluida ? "Concluída" : "Pendente";
                Console.WriteLine($"{i + 1}. {tarefa.Titulo} - {status}");
            }
        }

        // Método para marcar uma tarefa como concluída
        static void MarcarTarefaConcluida()
        {
            ListarTarefas();

            Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero > 0 && numero <= tarefas.Count)
            {
                tarefas[numero - 1].Concluida = true;
                Console.WriteLine("Tarefa marcada como concluída.");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido.");
            }
        }

        // Método para excluir uma tarefa
        static void ExcluirTarefa()
        {
            ListarTarefas();

            Console.Write("Digite o número da tarefa a ser excluída: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero > 0 && numero <= tarefas.Count)
            {
                tarefas.RemoveAt(numero - 1);
                Console.WriteLine("Tarefa excluída com sucesso.");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido.");
            }
        }
    }

    // Classe Tarefa que define os atributos de uma tarefa
    class Tarefa
    {
        public string Titulo { get; set; }
        public bool Concluida { get; set; }

        public Tarefa(string titulo)
        {
            Titulo = titulo;
            Concluida = false; // Por padrão, a tarefa é criada como "não concluída"
        }
    }
}
