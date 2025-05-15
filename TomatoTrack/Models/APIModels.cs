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
        public int TotalTomates { get; set; }

        [JsonProperty("maduros")]
        public int Maduros { get; set; }

        [JsonProperty("media_confianca")]
        public double MediaConfianca { get; set; }

        [JsonProperty("desvio_confianca")]
        public double DesvioConfianca { get; set; }

        public List<PredictionResult> results { get; set; }
    }

}
