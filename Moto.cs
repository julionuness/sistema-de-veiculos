class Moto : Veiculo
{
    public bool TemAntiTravamento { get; set; }

    public Moto(string modelo, int ano, bool temAntiTravamento) : base(modelo, ano)
    {
        TemAntiTravamento = temAntiTravamento;
    }

    public override double CalcularVelocidadeMedia()
    {
        // Exemplo simples de cálculo da velocidade média para uma moto
        return TemAntiTravamento ? 80 : 60;
    }

    public override string ObterTipo()
    {
        return "Moto";
    }
}
