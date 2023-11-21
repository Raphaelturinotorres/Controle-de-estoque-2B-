using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;

class Bloco
{
    // Definição da classe Bloco com propriedades para cada atributo do bloco
    public int Codigo { get; set; }
    public string Numero { get; set; }
    public double Medidas { get; set; }
    public string Descricao { get; set; }
    public string TipoMaterial { get; set; }
    public double ValorCompra { get; set; }
    public double ValorVenda { get; set; }
    public string Pedreira { get; set; }
}

class Program
{
    // Lista para armazenar os objetos da classe Bloco
    static List<Bloco> blocos = new List<Bloco>();

    // Objeto CultureInfo para lidar com formatação numérica
    static CultureInfo Culture = CultureInfo.InvariantCulture;

    // Método principal
    static void Main()
    {
        int escolha;

        do
        {
            // Menu de opções
            Console.WriteLine(">>> Gestão de Blocos <<<");
            Console.WriteLine("1 - Cadastrar Bloco");
            Console.WriteLine("2 - Listar Blocos");
            Console.WriteLine("3 - Buscar Bloco por código");
            Console.WriteLine("4 - Listar Blocos por pedreira");
            Console.WriteLine("5 - Salvar em arquivo");
            Console.WriteLine("6 - Exibir arquivo no console");
            Console.WriteLine("7 - SAIR");

            // Leitura da escolha do usuário
            escolha = int.Parse(Console.ReadLine());

            // Switch para determinar a ação com base na escolha do usuário
            switch (escolha)
            {
                case 1:
                    CadastrarBloco();
                    break;
                case 2:
                    ListarBlocos();
                    break;
                case 3:
                    BuscarBlocoPorCodigo();
                    break;
                case 4:
                    ListarBlocosPorPedreira();
                    break;
                case 5:
                    SalvarEmArquivo();
                    break;
                case 6:
                    ExibirArquivoNoConsole();
                    break;
                case 7:
                    Console.WriteLine("Saindo do programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        } while (escolha != 7);
    }

    // Método para cadastrar um novo bloco
    static void CadastrarBloco()
    {
        Bloco bloco = new Bloco();

        // Preenchimento das propriedades do bloco
        Console.WriteLine("Digite o Código do Bloco:");
        bloco.Codigo = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o Número do Bloco:");
        bloco.Numero = Console.ReadLine();

        Console.WriteLine("Digite as Medidas (metros cúbicos):");
        bloco.Medidas = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite a Descrição:");
        bloco.Descricao = Console.ReadLine();

        Console.WriteLine("Digite o Tipo de Material (mármore ou granito):");
        bloco.TipoMaterial = Console.ReadLine();

        Console.WriteLine("Digite o Valor de Compra:");
        bloco.ValorCompra = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite o Valor de Venda:");
        bloco.ValorVenda = double.Parse(Console.ReadLine(), Culture);

        Console.WriteLine("Digite a Pedreira:");
        bloco.Pedreira = Console.ReadLine();

        // Adição do bloco à lista
        blocos.Add(bloco);

        Console.WriteLine("Bloco cadastrado com sucesso!");
    }

    // Método para listar todos os blocos
    static void ListarBlocos()
    {
        Console.WriteLine("Lista de Blocos:");

        // Iteração sobre a lista de blocos e exibição das informações
        foreach (var bloco in blocos)
        {
            Console.WriteLine($"Código: {bloco.Codigo}, Número: {bloco.Numero}, Medidas: {bloco.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {bloco.Descricao}");
        }
    }

    // Método para buscar um bloco por código
    static void BuscarBlocoPorCodigo()
    {
        Console.WriteLine("Digite o Código do Bloco a ser buscado:");
        int codigo = int.Parse(Console.ReadLine());

        // Utilização do método Find para buscar um bloco na lista
        Bloco blocoEncontrado = blocos.Find(bloco => bloco.Codigo == codigo);

        // Exibição do bloco encontrado ou mensagem de que não foi encontrado
        if (blocoEncontrado != null)
        {
            Console.WriteLine($"Código: {blocoEncontrado.Codigo}, Número: {blocoEncontrado.Numero}, Medidas: {blocoEncontrado.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {blocoEncontrado.Descricao}");
        }
        else
        {
            Console.WriteLine("Bloco não encontrado.");
        }
    }

    // Método para listar blocos de uma pedreira específica
    static void ListarBlocosPorPedreira()
    {
        Console.WriteLine("Digite o nome da Pedreira:");
        string pedreira = Console.ReadLine();

        Console.WriteLine($"Blocos da Pedreira '{pedreira}':");

        // Iteração sobre a lista de blocos e exibição dos blocos da pedreira especificada
        foreach (var bloco in blocos)
        {
            if (bloco.Pedreira == pedreira)
            {
                Console.WriteLine($"Código: {bloco.Codigo}, Número: {bloco.Numero}, Medidas: {bloco.Medidas.ToString("F2", Culture)} metros cúbicos, Descrição: {bloco.Descricao}");
            }
        }
    }

    // Método para salvar os blocos em um arquivo de texto
    static void SalvarEmArquivo()
    {
        // Utilização do StreamWriter para escrever os dados no arquivo
        using (StreamWriter writer = new StreamWriter("blocos.txt"))
        {
            foreach (var bloco in blocos)
            {
                // Escrita de cada bloco no formato CSV no arquivo
                writer.WriteLine($"{bloco.Codigo},{bloco.Numero},{bloco.Medidas},{bloco.Descricao},{bloco.TipoMaterial},{bloco.ValorCompra},{bloco.ValorVenda},{bloco.Pedreira}");
            }
        }

        Console.WriteLine("Blocos salvos em arquivo.");
    }

    // Método para exibir o conteúdo do arquivo no console
    static void ExibirArquivoNoConsole()
    {
        // Verifica se o arquivo existe antes de tentar lê-lo
        if (File.Exists("blocos.txt"))
        {
            // Utilização do StreamReader para ler o conteúdo do arquivo
            using (StreamReader reader = new StreamReader("blocos.txt"))
            {
                // Leitura do conteúdo e exibição no console
                string conteudo = reader.ReadToEnd();
                Console.WriteLine("Conteúdo do arquivo:");
                Console.WriteLine(conteudo);
            }
        }
        else
        {
            Console.WriteLine("O arquivo de blocos não existe.");
        }
    }
}