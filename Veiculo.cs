using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

class Veiculo
{
    private string modelo;
    private int ano;

    public string Modelo { get => modelo; set => modelo = value; }
    public int Ano { get => ano; set => ano = value; }

    public Veiculo(string _modelo, int _ano)
    {
        Modelo = _modelo;
        Ano = _ano;
    }

    // Polimorfismo: será sobrescrita
    public virtual double CalcularVelocidadeMedia()
    {
        return 0;
    }

    // Polimorfismo: será sobrescrita
    public virtual string ObterTipo()
    {
        return "Veículo";
    }

    // Salvar as informações dos veículos em arquivo (nesse caso 'virtual' é opcional).
    public virtual void SalvarVeiculosEmArquivo(List<Veiculo> veiculos, bool salvarTodos = true)
    {
        try
        {
            // Salvar todos os veículos cadastrados na lista veiculos em um só arquivo
            if (salvarTodos)
            {
                string fileName = "Veiculos.txt";
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var veiculo in veiculos)
                    {
                        SalvarDadosVeiculo(writer, veiculo);
                        writer.WriteLine();
                    }
                }
                Console.WriteLine($"Veículos salvos com sucesso em {fileName}!");
            }
            else
            {
                // Para cada veículo na lista veiculos, obtenha o tipo do veículo, considerando apenas tipos de veículos únicos
                //e salva os veículos em arquivos separados por tipo
                foreach (var tipoVeiculo in veiculos.Select(v => v.ObterTipo()).Distinct())
                {
                    string fileName = $"{tipoVeiculo}.txt";
                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        // Para cada tipo de veículo (carro e moto)
                        foreach (var veiculo in veiculos.Where(v => v.ObterTipo() == tipoVeiculo))
                        {
                            SalvarDadosVeiculo(writer, veiculo);
                            writer.WriteLine();
                        }
                    }
                    Console.WriteLine($"Veículos do tipo {tipoVeiculo} salvos com sucesso em {fileName}!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar veículos: {ex.Message}");
        }
    }

    // Função para facilitar o salvamento sem duplicar o código
    private void SalvarDadosVeiculo(StreamWriter writer, Veiculo veiculo)
    {
        writer.WriteLine($"Tipo: {veiculo.ObterTipo()}");
        writer.WriteLine($"Modelo: {veiculo.Modelo}");
        writer.WriteLine($"Ano: {veiculo.Ano}");
        if (veiculo is Carro carro)
        {
            writer.WriteLine($"Potência: {carro.Potencia}");
        }
        else if (veiculo is Moto moto)
        {
            writer.WriteLine($"Sistema Anti-Travamento: {moto.TemAntiTravamento}");
        }
        writer.WriteLine($"Velocidade Média: {veiculo.CalcularVelocidadeMedia()} km/h");
    }

    // Mostrar lista de veículos cadastrados ('static' para ser acessado sem precisar instanciar veiculo)
    public static void ListarVeiculos(List<Veiculo> veiculos)
    {
        Console.WriteLine("Veículos Cadastrados:");
        foreach (var veiculo in veiculos)
        {
            Console.WriteLine($"\nTipo: {veiculo.ObterTipo()}");
            Console.WriteLine($"Modelo: {veiculo.Modelo}");
            Console.WriteLine($"Ano: {veiculo.Ano}");
            Console.WriteLine($"Velocidade Média: {veiculo.CalcularVelocidadeMedia()} km/h");
        }
    }
}
