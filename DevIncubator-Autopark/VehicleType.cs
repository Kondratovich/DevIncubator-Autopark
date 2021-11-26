using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIncubatorAutopark
{
    internal class VehicleType
    {
        public string TypeName { get; set; }
        public float TaxCoefficient { get; set; }
        public VehicleType(string carType, float taxCoefficient = 1)
        {
            TypeName = carType;
            TaxCoefficient = taxCoefficient;
        }
        public override string ToString() => $"{TypeName},\"{TaxCoefficient}\"";

        public void Display() => Console.WriteLine($"TypeName={TypeName}\nTaxCoefficient={TaxCoefficient}");
    }
}
