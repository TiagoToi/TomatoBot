using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using TomatoTrack.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;

namespace TomatoTrack.Helpers
{
    public class APIHelper
    {
        public static async Task<LoteModel> AnalisaImagens(List<String> filePaths)
        {
            var client = new HttpClient()
            {
                Timeout = TimeSpan.FromMinutes(2) 
            };
            var content = new MultipartFormDataContent();

            foreach (var path in filePaths)
            {
                var fileContent = new ByteArrayContent(File.ReadAllBytes(path));
                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                content.Add(fileContent, "files", Path.GetFileName(path));
            }

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                //response = await client.PostAsync("http://localhost:8000/predict", content) // LOCAL
                response = await client.PostAsync("https://TomatoBot.onrender.com/predict", content);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar as imagens. " + ex.ToString());
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao processar as imagens. " + await response.Content.ReadAsStringAsync());
            }

            string responseString = await response.Content.ReadAsStringAsync();
            ApiResponse parsed = JsonConvert.DeserializeObject<ApiResponse>(responseString);

            List<byte[]> resultadoImagensBytes = new List<byte[]>();

            foreach (PredictionResult result in parsed.results)
            {
                byte[] imageBytes = Convert.FromBase64String(result.image_base64);
                resultadoImagensBytes.Add(imageBytes);
            }

            LoteModel resultado = new LoteModel()
            {
                Imagens = resultadoImagensBytes,
                TotalTomates = parsed.TotalTomates,
                TomatesMaduros = parsed.Maduros,
                PorcentagemAcertoIA = parsed.MediaConfianca,
                desvioPadrao = parsed.DesvioConfianca,
                NumeroImagens = filePaths.Count                
            };

            return resultado;
        }
    }
}
