﻿namespace DevIncubatorAutopark
{
    internal class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; }

        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1d)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;
    }
}
