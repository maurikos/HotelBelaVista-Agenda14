
namespace testeMAUI.Models;

public class Suite
{
    public string Nome { get; set; } = string.Empty;

    public decimal ValorDiaria { get; set; }

    public int Capacidade { get; set; }

    public Suite(string nome, decimal valorDiaria,
                 int capacidade)
    {
        Nome = nome;
        ValorDiaria = valorDiaria;
        Capacidade = capacidade;
    }
}
