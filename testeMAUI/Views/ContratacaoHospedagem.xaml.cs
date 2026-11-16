
using System.Globalization;
using testeMAUI.Models;

namespace testeMAUI.Views;

public partial class ContratacaoHospedagem : ContentPage
{

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        dtpck_checkout.Date = DateTime.Today.AddDays(1);

        List<Suite> suites = new List<Suite>
    {
        new Suite("Suíte Standard", 180m, 2),
        new Suite("Suíte Luxo", 280m, 4),
        new Suite("Suíte Premium", 420m, 6)
    };

        pck_quarto.ItemsSource = suites;
    }


    private async void OnCalcularClicked(object? sender, EventArgs e)
    {
        if (pck_quarto.SelectedIndex == -1)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Selecione uma suíte.",
                "OK");
            return;
        }

        DateTime checkin = dtpck_checkin.Date ?? DateTime.Today;
        DateTime checkout = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

        int noites = (checkout - checkin).Days;

        if (noites <= 0)
        {
            await DisplayAlertAsync(
                "Data inválida",
                "O check-out deve ser posterior ao check-in.",
                "OK");
            return;
        }


        Suite suiteSelecionada = (Suite)pck_quarto.SelectedItem!;

        string suite = suiteSelecionada.Nome;
        decimal diaria = suiteSelecionada.ValorDiaria;

        int adultos = (int)stp_adultos.Value;
        int criancas = (int)stp_criancas.Value;

        if (adultos + criancas > suiteSelecionada.Capacidade)
        {
            await DisplayAlertAsync(
                "Capacidade excedida",
                $"A {suite} permite no máximo " +
                $"{suiteSelecionada.Capacidade} hóspedes.",
                "OK");
            return;
        }

        decimal total = diaria * noites;





        await Navigation.PushModalAsync(
            new HospedagemContratada(
                suite,
                adultos,
                criancas,
                checkin,
                checkout,
                noites,
                total));

    }
}
