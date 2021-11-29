namespace DevIncubatorAutopark
{
    internal class VehicleType
    {
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public VehicleType(string carType, double taxCoefficient = 1)
        {
            TypeName = carType;
            TaxCoefficient = taxCoefficient;
        }

        public override string ToString() => $"{TypeName},{TaxCoefficient}";

        public void Display() => Console.WriteLine($"TypeName={TypeName}\nTaxCoefficient={TaxCoefficient}");
    }
}
