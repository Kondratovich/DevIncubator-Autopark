namespace DevIncubatorAutopark
{
    internal class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100km) : base("Diesel", 1.2d)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100km = fuelConsumptionPer100km;
        }
    }
}
