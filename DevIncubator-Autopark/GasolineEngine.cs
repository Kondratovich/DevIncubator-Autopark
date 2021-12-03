namespace DevIncubatorAutopark
{
    internal class GasolineEngine : AbstractCombustionEngine
    {
        public GasolineEngine(double engineCapacity, double fuelConsumptionPer100km) : base("Gasoline", 1d)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100km = fuelConsumptionPer100km;
        }
    }
}
