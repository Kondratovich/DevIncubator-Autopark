namespace DevIncubatorAutopark
{
    internal abstract class AbstractCombustionEngine : AbstractEngine
    {
        private const double OneHundredPercent = 100d;

        public double EngineCapacity { get; protected set; }
        public double FuelConsumptionPer100km { get; protected set; }

        public AbstractCombustionEngine(string typeName, double taxCoefficient) : base(typeName, taxCoefficient)
        {
        }

        public override double GetMaxKilometers(double fuelTankCapacity) =>
            fuelTankCapacity * OneHundredPercent / FuelConsumptionPer100km;
    }
}
