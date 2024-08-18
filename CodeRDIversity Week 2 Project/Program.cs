
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

class Program
{
    static void Main()
    {
        var geladeira = new Geladeira(3, 2, 4); 

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Adicionar item");
            Console.WriteLine("2. Remover item");
            Console.WriteLine("3. Visualizar itens");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarItem(geladeira);
                    break;

                case "2":
                    RemoverItem(geladeira);
                    break;

                case "3":
                    geladeira.MostrarItens();
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void AdicionarItem(Geladeira geladeira)
    {
        Console.Write("Nome do item: ");
        var nomeItem = Console.ReadLine();

        Console.Write("Número do andar (0 a 2): ");
        int andar = int.Parse(Console.ReadLine());

        Console.Write("Número do container (0 ou 1): ");
        int container = int.Parse(Console.ReadLine());

        Console.Write("Posição no container (0 a 3): ");
        int posicao = int.Parse(Console.ReadLine());

        try
        {
            geladeira.ObterAndar(andar).ObterContainer(container).AdicionarItem(new Item(nomeItem), posicao);
            Console.WriteLine($"Item '{nomeItem}' adicionado ao andar {andar}, container {container}, posição {posicao}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void RemoverItem(Geladeira geladeira)
    {
        Console.Write("Número do andar (0 a 2): ");
        int andar = int.Parse(Console.ReadLine());

        Console.Write("Número do container (0 ou 1): ");
        int container = int.Parse(Console.ReadLine());

        Console.Write("Posição no container (0 a 3): ");
        int posicao = int.Parse(Console.ReadLine());

        try
        {
            var itemRemovido = geladeira.ObterAndar(andar).ObterContainer(container).RemoverItem(posicao);
            Console.WriteLine($"Item '{itemRemovido.Nome}' removido do andar {andar}, container {container}, posição {posicao}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}
