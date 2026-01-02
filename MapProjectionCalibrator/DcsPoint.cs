using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MapProjectionCalibrator
{
    internal class DcsPoint
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("x")]
        public double X { get; set; }

        [JsonPropertyName("z")]
        public double Z { get; set; }
    }
}
