using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.BasicConverter.Solution
{
    /// <summary>
    /// class containing unit information: name, if it is a reference unit, and the conversion
    /// factor based on the reference unit
    /// </summary>
    public class LengthEnglish
    {
        public string UnitName { get; set; }
        public bool UnitConversionReference { get; set; }
        public double UnitConversionFactor { get; set; }

        public override string ToString()
        {
            return string.Format(UnitName);
        }
    }
}
