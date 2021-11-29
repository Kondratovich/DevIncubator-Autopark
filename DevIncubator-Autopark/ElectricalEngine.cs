﻿namespace DevIncubatorAutopark
{
    internal class ElectricalEngine : Engine
    {
        public double ElectricityConsumption { get; }

        public ElectricalEngine(double electricityConsumption) : base("Electrical", 0.1d)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;
    }
}
