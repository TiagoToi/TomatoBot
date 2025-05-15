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
using System.Windows.Shapes;
using TomatoTrack.Models;

namespace TomatoTrack
{
    /// <summary>
    /// Lógica interna para MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        private int IdUser;
        private string nomeUser;
        public MainMenuWindow(int IdUser, String nomeUser)
        {
            InitializeComponent();
            this.IdUser = IdUser;
            this.nomeUser = nomeUser;
            BemVindoTextBox.Text += nomeUser + "!";
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = null;
        }

        private void Enviar_Click(object sender, RoutedEventArgs e)
        {
            var enviarImagensPage = new EnviarImagensPage(this);
            MainContent.Content = enviarImagensPage;
        }

        private void Lotes_Click(object sender, RoutedEventArgs e)
        {
            var verLotes = new LotesPage(IdUser, nomeUser);
            MainContent.Content = verLotes;
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Deseja fechar o programa?", "Sair", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
            {
                return;
            }
            Environment.Exit(0);
        }

        public void mostrarResultadoAnalise(LoteModel resultado)
        {
            ResultadoAnalisePage paginaResultado = new ResultadoAnalisePage(this, resultado, IdUser);
            MainContent.Content = paginaResultado;
        }

        public void reenviarImagens()
        {
            var enviarImagensPage = new EnviarImagensPage(this);
            MainContent.Content = enviarImagensPage;
        }
    }
}
