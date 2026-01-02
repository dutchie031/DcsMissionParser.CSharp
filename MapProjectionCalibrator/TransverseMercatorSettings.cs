using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProjectionCalibrator
{
    internal class TransverseMercatorSettings
    {
        public double CentralMeridian { get; set; }
        public double ScaleFactor { get; set; }
        public double FalseEasting { get; set; }
        public double FalseNorthing { get; set; }
    }
}
