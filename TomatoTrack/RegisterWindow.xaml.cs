using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TomatoTrack
{
    /// <summary>
    /// Interação lógica para RegisterWindow.xam
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private bool senhaVisivel = false;
        private bool confirmarVisivel = false;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void CriarConta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NomeTextBox.Text) || string.IsNullOrEmpty(SenhaBox.Password) || string.IsNullOrEmpty(EmailTextBox.Text) || string.IsNullOrEmpty(ConfirmarSenhaTextBox.Text))
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }
            if (SenhaBox.Password != ConfirmarSenhaTextBox.Text)
            {
                MessageBox.Show("As senhas não coincidem.");
                return;
            }

            bool cadastrou = operacoesBD.criarUser(NomeTextBox.Text, SenhaBox.Password, EmailTextBox.Text);

            if (cadastrou)
            {
                NomeTextBox.Text = "";
                SenhaBox.Password = "";
                EmailTextBox.Text = "";
                ConfirmarSenhaTextBox.Text = "";
            }
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void MostrarSenha_Click(object sender, RoutedEventArgs e)
        {
            senhaVisivel = !senhaVisivel;

            if (senhaVisivel)
            {
                SenhaTextBox.Text = SenhaBox.Password;
                SenhaBox.Visibility = Visibility.Collapsed;
                SenhaTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                SenhaBox.Password = SenhaTextBox.Text;
                SenhaTextBox.Visibility = Visibility.Collapsed;
                SenhaBox.Visibility = Visibility.Visible;
            }
        }

        private void MostrarConfirmarSenha_Click(object sender, RoutedEventArgs e)
        {
            confirmarVisivel = !confirmarVisivel;

            if (confirmarVisivel)
            {
                ConfirmarSenhaTextBox.Text = ConfirmarSenhaBox.Password;
                ConfirmarSenhaBox.Visibility = Visibility.Collapsed;
                ConfirmarSenhaTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                ConfirmarSenhaBox.Password = ConfirmarSenhaTextBox.Text;
                ConfirmarSenhaTextBox.Visibility = Visibility.Collapsed;
                ConfirmarSenhaBox.Visibility = Visibility.Visible;
            }
        }

        private void SenhaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!senhaVisivel) return;
            SenhaTextBox.Text = SenhaBox.Password;
        }

        private void SenhaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (senhaVisivel)
                SenhaBox.Password = SenhaTextBox.Text;
        }

        private void ConfirmarSenhaBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!confirmarVisivel) return;
            ConfirmarSenhaTextBox.Text = ConfirmarSenhaBox.Password;
        }

        private void ConfirmarSenhaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (confirmarVisivel)
                ConfirmarSenhaBox.Password = ConfirmarSenhaTextBox.Text;
        }

    }
}
