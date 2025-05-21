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
using TomatoTrack.Helpers;
using TomatoTrack.Models;

namespace TomatoTrack
{
    /// <summary>
    /// Interação lógica para LoteItem.xam
    /// </summary>
    public partial class LoteItem : UserControl
    {
        private bool detalhesVisiveis = false;

        public LoteModel Lote { get; set; }

        public LoteItem(LoteModel lote)
        {
            InitializeComponent();
            Lote = lote;
            txtNomeLote.Text = $"Lote de {lote.DataHora.ToString("dd/MM/yyyy HH:mm")}";
            txtTotalTomates.Text = lote.TotalTomates.ToString();
            txtNumImagens.Text = lote.NumeroImagens.ToString();
            txtTomatesMaduros.Text = lote.TomatesMaduros.ToString();
            int verdes = lote.TotalTomates - lote.TomatesMaduros;
            txtTomatesVerdes.Text = verdes.ToString();
            txtScoreMaduros.Text = lote.mediaScoreMaduros.ToString("F2") + $"% (desvio padrão: {lote.desvioPadraoMaduros})";
            txtScoreVerdes.Text = lote.mediaScoreVerdes.ToString("F2") + $"% (desvio padrão: {lote.desvioPadraoVerdes})";
        }

        private void BtnExpandir_Click(object sender, RoutedEventArgs e)
        {
            detalhesVisiveis = !detalhesVisiveis;
            DetalhesPanel.Visibility = detalhesVisiveis ? Visibility.Visible : Visibility.Collapsed;
            BtnExpandir.Content = detalhesVisiveis ? "Ocultar" : "+ Detalhes";
        }

        public void VisualizarImagens_Click(object sender, RoutedEventArgs e)
        {
            List<byte[]> imagens = operacoesBD.getImagens(Lote.Id);
            ImagensHelper.SalvarEAbrirImagens(imagens);
        }
    }    

}
