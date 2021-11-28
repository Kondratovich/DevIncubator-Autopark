namespace DevIncubatorAutopark
{
    internal static class VehicleHelper
    {
        public static void ShowVehicles(IReadOnlyList<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            };
        }
        public static Vehicle GetVehicleWithMaxMileage(IReadOnlyList<Vehicle> vehicles)
        {
            var maxMileageVehicle = vehicles[0];
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage > maxMileageVehicle.Mileage)
                {
                    maxMileageVehicle = vehicle;
                }
            };
            return maxMileageVehicle;
        }
        public static Vehicle GetVehicleWithMinMileage(IReadOnlyList<Vehicle> vehicles)
        {
            var minMileageVehicle = vehicles[0];
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Mileage < minMileageVehicle.Mileage)
                {
                    minMileageVehicle = vehicle;
                }
            };
            return minMileageVehicle;
        }
    }
}
