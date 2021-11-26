using System.Collections.Generic;

namespace DevIncubatorAutopark
{
    class Program
    {
        public static void Main()
        {
            //1
            VehicleType[] vehicleTypes = new VehicleType[]
            {
               new VehicleType("Bus", 1.2f),
               new VehicleType("Car"),
               new VehicleType("Rink", 1.5f),
               new VehicleType("Tractor", 1.2f)
            };

            //2
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
            }

            //3
            vehicleTypes[^1].TaxCoefficient = 1.3f;

            //4
            Console.WriteLine($"Max TaxCoefficient = {GetMaxTaxCoefficient(vehicleTypes)}");

            //5
            Console.WriteLine($"Average TaxCoefficient = {GetAverageTaxCoefficient(vehicleTypes)}");

            //6
            float maxTaxCoefficient = 0;
            float sumOfTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }
                sumOfTaxCoefficient += vehicleType.TaxCoefficient;
            }
            float averageTaxCoefficient = sumOfTaxCoefficient / vehicleTypes.Length;

            //7
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }
        }
        public static float GetMaxTaxCoefficient(IReadOnlyList<VehicleType> vehicleTypes)
        {
            float maxTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }
            }
            return maxTaxCoefficient;
        }

        public static float GetAverageTaxCoefficient(IReadOnlyList<VehicleType> vehicleTypes)
        {
            float sumOfTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                sumOfTaxCoefficient += vehicleType.TaxCoefficient;
            }
            return sumOfTaxCoefficient / vehicleTypes.Count;
        }
    }
}