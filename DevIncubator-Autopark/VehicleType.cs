namespace DevIncubatorAutopark
{
    internal class VehicleType
    {
        public int Id { get; }
        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public VehicleType(int id, string carType, double taxCoefficient = 1)
        {
            Id = id;
            TypeName = carType;
            TaxCoefficient = taxCoefficient;
        }

        public override string ToString() => $"{TypeName},{TaxCoefficient}";

        public void Display() => Console.WriteLine($"TypeName={TypeName}\nTaxCoefficient={TaxCoefficient}");
    }
}
