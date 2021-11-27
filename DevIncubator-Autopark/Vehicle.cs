namespace DevIncubatorAutopark
{
    internal class Vehicle : IComparable<Vehicle>
    {
        public readonly VehicleType VehicleType;
        public readonly string Model;
        public readonly string LicensePlate;
        public readonly double Weight;
        public readonly int YearIssue;
        public readonly double Mileage;
        public readonly CarColor Color;
        public readonly double TankCapacity;
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
        public double GetCalcTaxPerMonth() => (Weight * 0.0013) + (VehicleType.TaxCoefficient * 30) + 5;
        public override string ToString() => $"{VehicleType};{Model};{LicensePlate};{Weight};" +
            $"{YearIssue};{Mileage};{Color};{TankCapacity};{GetCalcTaxPerMonth().ToString("0.00")}";
        public int CompareTo(Vehicle other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");
            return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
        }
    }
}
