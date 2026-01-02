using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MapProjectionCalibrator
{
    internal class DcsExportData
    {
        [JsonPropertyName("reference_points")]
        public List<DcsPoint> ReferencePoints { get; set; } = [];

        [JsonPropertyName("test_points")]
        public List<DcsPoint> TestPoints { get; set; } = [];
    }
}
