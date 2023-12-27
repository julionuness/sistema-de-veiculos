using System.Collections.Generic;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Lista para cadastrar e imprimir veículos cadastrados
        List<Veiculo> veiculos = new List<Veiculo>();

        int opcao;

        do
        {
            Console.WriteLine("Bem-vindo(a)!");
            Console.WriteLine("[1] – Incluir Veículo");
            Console.WriteLine("[2] – Mostrar Lista de Veículos");
            Console.WriteLine("[3] – Salvar Veículos no Arquivo");
            Console.WriteLine("[4] – Sair");
            Console.Write("Informe a opção desejada: ");

            // Tenta converter a string lida pelo console para um valor inteiro
            //retorna true se a conversão for bem-sucedida e armazena o valor convertido em 'opcao',
            //caso contrário, retorna false, e 'opcao' mantém seu valor padrão.
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        Veiculo novoVeiculo = IncluirVeiculo();
                        if (novoVeiculo != null)
                        {
                            veiculos.Add(novoVeiculo);
                            Console.WriteLine($"{novoVeiculo.ObterTipo()} incluído com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum veículo foi incluído.");
                        }
                        break;

                    case 2:
                        Veiculo.ListarVeiculos(veiculos);
                        break;

                    case 3:
                        SalvarVeiculos(veiculos);
                        break;

                    case 4:
                        Console.WriteLine("Saindo do programa. Obrigado!");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine();
        } while (opcao != 4);
    }

    // Método para facilitar a inclusão dos veículos pelo tipo
    static Veiculo IncluirVeiculo()
    {
        Console.Write("Informe o modelo do veículo: ");
        string modelo = Console.ReadLine();

        Console.Write("Informe o ano do veículo: ");

        if (int.TryParse(Console.ReadLine(), out int ano))
        {
            Console.WriteLine("Escolha o tipo de veículo:");
            Console.WriteLine("[1] - Carro");
            Console.WriteLine("[2] - Moto");

            if (int.TryParse(Console.ReadLine(), out int tipoVeiculo))
            {
                // Retornar o tipo de veículo incluído
                switch (tipoVeiculo)
                {
                    case 1:
                        return IncluirCarro(modelo, ano);
                    case 2:
                        return IncluirMoto(modelo, ano);
                    default:
                        Console.WriteLine("Opção de tipo de veículo inválida.");
                        return null;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida.");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Ano inválido.");
            return null;
        }
    }

    static Carro IncluirCarro(string modelo, int ano)
    {
        Console.Write("Informe a potência do carro: ");

        if (int.TryParse(Console.ReadLine(), out int potencia))
        {
            return new Carro(modelo, ano, potencia);
        }
        else
        {
            Console.WriteLine("Potência inválida.");
            return null;
        }
    }

    static Moto IncluirMoto(string modelo, int ano)
    {
        while (true)
        {
            Console.Write("O sistema anti-travamento está presente na moto? (S/n): ");

            // Lê a resposta do usuário ou considera como 'S' se pressionar Enter
            string resposta = Console.ReadLine().ToUpper();

            if (string.IsNullOrEmpty(resposta) || resposta == "S")
            {
                return new Moto(modelo, ano, true);
            }
            else
            {
                return new Moto(modelo, ano, false);
            }
        }
    }

    // Chamar o método para salvar os veículos em arquivos
    static void SalvarVeiculos(List<Veiculo> veiculos)
    {
        Console.Write("Deseja salvar todos em um único arquivo? (S/n) ");

        // Lê a resposta do usuário ou considera como 'S' se pressionar Enter
        string resposta = Console.ReadLine().ToUpper();
        bool salvarTodos = string.IsNullOrEmpty(resposta) || resposta == "S";

        Veiculo veiculo = veiculos.FirstOrDefault(); // Pode ser qualquer veículo da lista
        if (veiculo != null)
        {
            veiculo.SalvarVeiculosEmArquivo(veiculos, salvarTodos);
        }
        else
        {
            Console.WriteLine("Nenhum veículo encontrado para salvar.");
        }
    }
}
