namespace DevIncubatorAutopark
{
    internal class Vehicle : IComparable<Vehicle>
    {
        public VehicleType VehicleType { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public double Weight { get; set; }
        public int YearIssue { get; set; }
        public double Mileage { get; set; }
        public CarColor Color { get; set; }
        public float TankCapacity { get; set; }
        public Vehicle() { }
        public Vehicle(VehicleType vehicleType, string model, string licensePlate, double weight,
            int yearIssue, double mileage, CarColor color, float tankCapacity)
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
        public double GetCalcTaxPerMonth() => (Weight * 0.0013) + (VehicleType.TaxCoefficient * 30) + 5;
        public override string ToString() => $"{VehicleType};{Model};{LicensePlate};{Weight};" +
            $"{YearIssue};{Mileage};{Color};{TankCapacity}";
        public int CompareTo(Vehicle other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");
            return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
        }
    }
}
