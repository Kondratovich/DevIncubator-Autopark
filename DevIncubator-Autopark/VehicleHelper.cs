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

        public static void PrintEqualsVehicles(IReadOnlyList<Vehicle> vehicles)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                for (int j = i + 1; j < vehicles.Count; j++)
                {
                    if (vehicles[i].Equals(vehicles[j]))
                    {
                        Console.WriteLine($"Equals:\n{vehicles[i]}\n{vehicles[j]}");
                    }
                }
            }
        }

        public static Vehicle GetVehicleWithMaxKilometers(IReadOnlyList<Vehicle> vehicles)
        {
            Vehicle vehicleWithMaxKilometers = vehicles[0];
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].VehicleEngine.GetMaxKilometers(vehicles[i].TankCapacity) > vehicleWithMaxKilometers.VehicleEngine.GetMaxKilometers(vehicleWithMaxKilometers.TankCapacity))
                {
                    vehicleWithMaxKilometers = vehicles[i];
                }
            }
            return vehicleWithMaxKilometers;
        }
    }
}
