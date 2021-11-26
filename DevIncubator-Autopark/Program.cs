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
            vehicleTypes.Last().TaxCoefficient = 1.3f;

            //4
            Console.WriteLine($"Max TaxCoefficient = {GetMaxTaxCoefficient(vehicleTypes)}");

            //5
            Console.WriteLine($"Max TaxCoefficient = {GetAverageTaxCoefficient(vehicleTypes)}");

            //6
            float maxTaxCoefficient = 0;
            float averageTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }
                averageTaxCoefficient += vehicleType.TaxCoefficient;
            }
            averageTaxCoefficient = averageTaxCoefficient / vehicleTypes.Length;

            //7
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }
        }
        public static float GetMaxTaxCoefficient(VehicleType[] vehicleTypes)
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

        public static float GetAverageTaxCoefficient(VehicleType[] vehicleTypes)
        {
            float averageTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                averageTaxCoefficient += vehicleType.TaxCoefficient;
            }
            return averageTaxCoefficient / vehicleTypes.Length;
        }
    }
}