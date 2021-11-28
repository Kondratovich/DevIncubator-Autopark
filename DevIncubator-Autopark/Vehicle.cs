namespace DevIncubatorAutopark
{
    internal class Vehicle : IComparable<Vehicle>
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxChange = 5d;
        private const double TaxCoefficient = 30d;

        public VehicleType VehicleType { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public double Weight { get; }
        public int YearIssue { get; }
        public double Mileage { get; }
        public CarColor Color { get; }
        public double TankCapacity { get; }

        public Vehicle() { }
        public Vehicle(VehicleType vehicleType, string model, string licensePlate, double weight,
            int yearIssue, double mileage, CarColor color, double tankCapacity)
        {
            VehicleType = vehicleType;
            Model = model;
            LicensePlate = licensePlate;
            Weight = weight;
            YearIssue = yearIssue;
            Mileage = mileage;
            Color = color;
            TankCapacity = tankCapacity;
        }

        public double GetCalcTaxPerMonth() => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + TaxChange;
        
        public override string ToString() => $"{VehicleType},{Model},{LicensePlate},{Weight}," +
            $"{YearIssue},{Mileage},{Color},{TankCapacity},{GetCalcTaxPerMonth().ToString("0.00")}";
        
        public int CompareTo(Vehicle other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");
            return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
        }
    }
}
