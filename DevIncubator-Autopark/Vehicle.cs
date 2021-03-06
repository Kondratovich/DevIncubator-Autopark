namespace DevIncubatorAutopark
{
    internal class Vehicle : IComparable<Vehicle>
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxChange = 5d;
        private const double TaxCoefficient = 30d;

        public int Id { get; }
        public List<Rent> Rents { get; set; } = new List<Rent>();
        public VehicleType VehicleType { get; }
        public string Model { get; }
        public int YearIssue { get; }
        public double TankCapacity { get; }
        public double Weight { get; }
        public AbstractEngine VehicleEngine { get; set; }
        public string LicensePlate { get; set; }
        public double Mileage { get; set; }
        public CarColor Color { get; set; }

        public Vehicle() { }
        public Vehicle(int id, VehicleType vehicleType, AbstractEngine vehicleEngine, string model, string licensePlate, double weight,
            int yearIssue, double mileage, CarColor color, double tankCapacity)
        {
            Id = id;
            VehicleType = vehicleType;
            VehicleEngine = vehicleEngine;
            Model = model;
            LicensePlate = licensePlate;
            Weight = weight;
            YearIssue = yearIssue;
            Mileage = mileage;
            Color = color;
            TankCapacity = tankCapacity;
        }

        public override string ToString() => $"{VehicleType}, {VehicleEngine.TypeName}, {Model},{LicensePlate},{Weight}," +
            $"{YearIssue},{Mileage},{Color},{TankCapacity},{GetCalcTaxPerMonth().ToString("0.00")}";

        public override bool Equals(object obj)
        {
            return obj is Vehicle secondVehicle && Model == secondVehicle.Model && VehicleType == secondVehicle.VehicleType;
        }

        public double GetCalcTaxPerMonth()
            => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * VehicleEngine.TaxCoefficient * TaxCoefficient) + TaxChange;

        public int CompareTo(Vehicle other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");
            return GetCalcTaxPerMonth().CompareTo(other.GetCalcTaxPerMonth());
        }

        public double GetTotalIncome()
        {
            double totalIncome = 0d;
            foreach (var rent in Rents)
            {
                totalIncome += rent.RentPrice;
            }
            return totalIncome;
        }

        public double GetTotalProfit() => GetTotalIncome() - GetCalcTaxPerMonth();
    }
}
