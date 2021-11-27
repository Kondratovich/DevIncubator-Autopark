namespace DevIncubatorAutopark
{
    class Program
    {
        public static void Main()
        {
            //1
            VehicleType[] vehicleTypes = new VehicleType[]
            {
               new VehicleType("Bus", 1.2d),
               new VehicleType("Car"),
               new VehicleType("Rink", 1.5d),
               new VehicleType("Tractor", 1.2d)
            };

            //2
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
            }

            //3
            vehicleTypes[^1].TaxCoefficient = 1.3d;

            //4
            Console.WriteLine($"Max TaxCoefficient = {GetMaxTaxCoefficient(vehicleTypes)}");

            //5
            Console.WriteLine($"Average TaxCoefficient = {GetAverageTaxCoefficient(vehicleTypes)}");

            //6
            double maxTaxCoefficient = 0;
            double sumOfTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                vehicleType.Display();
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }
                sumOfTaxCoefficient += vehicleType.TaxCoefficient;
            }
            double averageTaxCoefficient = sumOfTaxCoefficient / vehicleTypes.Length;

            //7
            foreach (var vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType);
            }
        }
        public static double GetMaxTaxCoefficient(IReadOnlyList<VehicleType> vehicleTypes)
        {
            double maxTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                if (vehicleType.TaxCoefficient > maxTaxCoefficient)
                {
                    maxTaxCoefficient = vehicleType.TaxCoefficient;
                }
            }
            return maxTaxCoefficient;
        }

        public static double GetAverageTaxCoefficient(IReadOnlyList<VehicleType> vehicleTypes)
        {
            double sumOfTaxCoefficient = 0;
            foreach (var vehicleType in vehicleTypes)
            {
                sumOfTaxCoefficient += vehicleType.TaxCoefficient;
            }
            return sumOfTaxCoefficient / vehicleTypes.Count;
        }
    }
}