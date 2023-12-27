class Carro : Veiculo
{
    public int Potencia { get; set; }

    public Carro(string modelo, int ano, int potencia) : base(modelo, ano)
    {
        Potencia = potencia;
    }

    public override double CalcularVelocidadeMedia()
    {
        // Exemplo simples de cálculo da velocidade média para um carro
        return Potencia * 2.5;
    }

    public override string ObterTipo()
    {
        return "Carro";
    }
}
