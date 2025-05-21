using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomatoTrack.Models
{
    public class PredictionResult
    {
        public string filename { get; set; }
        public string image_base64 { get; set; }
        public string status { get; set; }
    }

    public class ApiResponse
    {
        [JsonProperty("total_tomates")]
        public int total_tomates { get; set; }

        [JsonProperty("maduros")]
        public int maduros { get; set; }                     

        [JsonProperty("media_confianca_maduros")]
        public double media_confianca_maduros { get; set; }

        [JsonProperty("media_confianca_verde")]
        public double media_confianca_verde { get; set; }

        [JsonProperty("desvio_confianca_maduros")]
        public double desvio_confianca_maduros { get; set; }

        [JsonProperty("desvio_confianca_verde")]
        public double desvio_confianca_verde { get; set; }

        public List<PredictionResult> results { get; set; }
    }

}
