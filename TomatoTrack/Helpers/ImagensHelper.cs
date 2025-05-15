using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace TomatoTrack.Helpers
{
    public static class ImagensHelper
    {
        private static readonly string PastaTemp = "C:\\Users\\TiagoToi\\OneDrive - Taxcel\\Documentos\\Puc\\TomatoTrack\\TomatoTrack\\ImagensTemp";

        public static void SalvarEAbrirImagens(List<byte[]> imagensBytes)
        {
            try
            {
                LimparPastaTemporaria();

                List<string> caminhosSalvos = new List<string>();
                int contador = 1;

                foreach (var imagemBytes in imagensBytes)
                {
                    string caminhoImagem = Path.Combine(PastaTemp, $"imagem_{contador}.jpg");

                    using (var ms = new MemoryStream(imagemBytes))
                    using (var imagem = Image.FromStream(ms))
                    {
                        imagem.Save(caminhoImagem, ImageFormat.Jpeg);
                    }

                    caminhosSalvos.Add(caminhoImagem);
                    contador++;
                }

                // Abre todas as imagens com o visualizador padrão
                foreach (var caminho in caminhosSalvos)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = caminho,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir imagens: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }

        // Método opcional: limpar a pasta temporária se quiser
        public static void LimparPastaTemporaria()
        {
            if (Directory.Exists(PastaTemp))
            {
                foreach (var arquivo in Directory.GetFiles(PastaTemp))
                {
                    try
                    {
                        if (arquivo.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                            File.Delete(arquivo);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao apagar {arquivo}: {ex.Message}");
                    }
                }
            }
        }

    }
}
