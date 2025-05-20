using Microsoft.Win32;
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
    /// Interação lógica para EnviarImagensPage.xam
    /// </summary>
    public partial class EnviarImagensPage : UserControl
    {
        MainMenuWindow mainMenu;
        public List<string> CaminhosImagensSelecionadas { get; set; } = new List<string>();

        public EnviarImagensPage(MainMenuWindow mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
        }

        private void SelecionarImagens_Click(object sender, MouseButtonEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,  // Permite a seleção de múltiplos arquivos
                Filter = "Imagens de Tomates|*.jpg;*.jpeg;*.png|Todos os Arquivos|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                // Adiciona as imagens selecionadas à lista de pré-visualização
                CaminhosImagensSelecionadas = openFileDialog.FileNames.ToList();
                if (CaminhosImagensSelecionadas.Count()>100){
                    CaminhosImagensSelecionadas = null;
                    MessageBox.Show("Selecione no máximo 100 imagens para análise.", "Atenção");
                    return;
                }
                PreviewImagens.ItemsSource = CaminhosImagensSelecionadas;
                TituloPreview.Visibility = Visibility.Visible;
                PreviewImagens.Visibility = Visibility.Visible;
                SelecionarImagens.Visibility = Visibility.Collapsed;
            }
        }

        private async void Enviar_Click(object sender, RoutedEventArgs e)
        {
            if (PreviewImagens.ItemsSource == null)
            {
                MessageBox.Show("Selecione uma imagem antes de continuar para análise.", "Atenção");
                return;
            }

            LoadingWindow loading = new LoadingWindow();
            loading.Show();

            LoteModel resultado = null;

            try
            {
                resultado = await APIHelper.AnalisaImagens(CaminhosImagensSelecionadas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Erro!");
                resultado = null;
            }

            loading.Close();


            if (resultado == null)
            {
                return;
            }

            mainMenu.mostrarResultadoAnalise(resultado);
        }

        private void EscolherNovamente_Click(object sender, RoutedEventArgs e)
        {
            PreviewImagens.ItemsSource = null;
            CaminhosImagensSelecionadas = null;
            TituloPreview.Visibility = Visibility.Collapsed;
            PreviewImagens.Visibility = Visibility.Collapsed;
            SelecionarImagens.Visibility = Visibility.Visible;
        }

        
    }
}
