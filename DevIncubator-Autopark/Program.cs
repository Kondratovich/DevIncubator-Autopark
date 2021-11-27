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
            Vehicle[] vehicles = new Vehicle[]
            {
                new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022d, 2015, 376000, CarColor.Blue, 200d),
                new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500d, 2014, 227010, CarColor.White, 200d),
                new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080d, 2019, 20451, CarColor.Grean, 200d),
                new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200d, 2006, 230451, CarColor.Gray, 90d),
                new Vehicle(vehicleTypes[1], "Tesla Model S 70D", "E001 AA-7", 2200d, 2019, 10454, CarColor.White, 7000d),
                new Vehicle(vehicleTypes[2], "Hamm HD 12VV", null, 1200d, 2016, 122, CarColor.Yellow, 90d),
                new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200d, 2020, 109, CarColor.Red, 440d)
            };

            //3
            VehicleHelper.ShowAllVehicles(vehicles);

            //4
            Array.Sort(vehicles);

            //5
            Console.WriteLine();
            VehicleHelper.ShowAllVehicles(vehicles);

            //6
            Console.WriteLine($"Vehicle with max mileage -> {VehicleHelper.GetVehicleWithMaxMileage(vehicles)}\n" +
                $"Vehicle with min mileage -> {VehicleHelper.GetVehicleWithMinMileage(vehicles)}");
        }
    }
}