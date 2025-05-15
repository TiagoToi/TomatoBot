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

namespace TomatoTrack
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool senhaVisivel = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            List<String> Id_NomeUser = operacoesBD.VerificaLogin(EmailTextBox.Text, PasswordBox.Password);

            if (Id_NomeUser == null) return;
            else if (Id_NomeUser.Count() <= 0)
            {
                MessageBox.Show("Email ou senha incorretos.");
                return;
            }

            MainMenuWindow menuPrincipal = new MainMenuWindow(int.Parse(Id_NomeUser[0]), Id_NomeUser[1]);
            menuPrincipal.Show();
            this.Close();
        }

        private void abrirMenu()
        {
            MainMenuWindow menuPrincipal = new MainMenuWindow(2, "Zezinho");
            menuPrincipal.Show();
            this.Close();
        }

        private void OpenRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void MostrarSenha_Click(object sender, RoutedEventArgs e)
        {
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                PasswordTextBox.Text = PasswordBox.Password;
                PasswordBox.Visibility = Visibility.Collapsed;
                PasswordTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordBox.Password = PasswordTextBox.Text;
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
            }
        }


        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!senhaVisivel) return;
            PasswordTextBox.Text = PasswordBox.Password;
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (senhaVisivel)
                PasswordBox.Password = PasswordTextBox.Text;
        }
    }
}
