using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TomatoTrack.Models;
using TomatoTrack.Helpers;
using System.Windows.Media.Animation;

namespace TomatoTrack
{
    /// <summary>
    /// Interação lógica para ResultadoAnalisePage.xam
    /// </summary>
    public partial class ResultadoAnalisePage : UserControl
    {
        MainMenuWindow mainMenuWindow;
        LoteModel resultado;
        int IdUser;
        public ResultadoAnalisePage(MainMenuWindow mainMenu, LoteModel resultado, int IdUser)
        {
            InitializeComponent();
            this.mainMenuWindow = mainMenu;
            this.resultado = resultado;
            DateTime horarioAtual = DateTime.Now;
            this.resultado.DataHora = horarioAtual;
            this.IdUser = IdUser;

            txtDataHora.Text = horarioAtual.ToString("dd/MM/yyyy HH:mm");
            txtTotalTomates.Text = resultado.TotalTomates.ToString();
            txtQntMaduros.Text = resultado.TomatesMaduros.ToString();
            //txtPrecisaoIA.Text = resultado.PorcentagemAcertoIA.ToString("F2") + "%";
            //txtDesvioPadrao.Text = resultado.desvioPadrao.ToString("F2");
            txtNumImagens.Text = resultado.NumeroImagens.ToString();
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            mainMenuWindow.reenviarImagens();
        }

        private void SalvarLote_Click(object sender, RoutedEventArgs e)
        {
            String horarioString = resultado.DataHora.ToString("dd/MM/yyyy HH:mm");
            bool exito = operacoesBD.SalvarLote(IdUser, horarioString, resultado.TotalTomates, resultado.TomatesMaduros, resultado.mediaScoreMaduros, resultado.desvioPadraoMaduros, resultado.mediaScoreVerdes, resultado.desvioPadraoVerdes, resultado.Imagens);

            if (exito)
            {
                btnSalvar.IsEnabled = false;
            }
        }

        private void verImagens_Click(object sender, RoutedEventArgs e)
        {
            ImagensHelper.SalvarEAbrirImagens(resultado.Imagens);
        }
    }
}
