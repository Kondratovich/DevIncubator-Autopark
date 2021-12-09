namespace DevIncubatorAutopark
{
    internal class Collections
    {
        public List<VehicleType> VehicleTypes { get; } = new List<VehicleType>();
        public List<Vehicle> Vehicles { get; } = new List<Vehicle>();

        public Collections()
        {

        }
        public Collections(string rentsFileName, string vehiclesFileName, string vehiclesTypesFileName)
        {
            VehicleTypes = ParseVehicleTypes(vehiclesTypesFileName);
            Vehicles = ParseVehicles(vehiclesFileName);
            LoadRents(rentsFileName);
        }

        private VehicleType GetVehicleTypeById(int id)
        {
            foreach (var vehicleType in VehicleTypes)
            {
                if (vehicleType.Id == id)
                {
                    return vehicleType;
                }
            }
            return null;
        }

        private void CreateRent(IReadOnlyList<string> fields)
        {
            var vehicleId = int.Parse(fields[0]);
            var rentTime = DateTime.Parse(fields[1]);
            var rentPrice = double.Parse(fields[2]);

            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleId)
                {
                    vehicle.Rents.Add(new Rent(rentTime, rentPrice));
                }
            }
        }

        private List<VehicleType> ParseVehicleTypes(string path)
        {
            var csvStrings = CsvHelper.ReadCsvStrings(path);
            foreach (var csvString in csvStrings)
            {
                VehicleTypes.Add(CreateVehicleType(csvString));
            }
            return VehicleTypes;
        }

        private List<Vehicle> ParseVehicles(string path)
        {
            var csvStrings = CsvHelper.ReadCsvStrings(path);
            foreach (var csvString in csvStrings)
            {
                Vehicles.Add(CreateVehicle(csvString));
            }
            return Vehicles;
        }

        private void LoadRents(string path)
        {
            var csvStrings = CsvHelper.ReadCsvStrings(path);
            foreach (var csvString in csvStrings)
            {
                List<String> fields = CsvHelper.ParseCsvStringToFields(csvString);
                CreateRent(fields);
            }
        }

        private VehicleType CreateVehicleType(string csvString)
        {
            var fields = CsvHelper.ParseCsvStringToFields(csvString);

            var id = int.Parse(fields[0]);
            var carType = fields[1];
            var taxCoefficient = double.Parse(fields[2]);

            return new VehicleType(id, carType, taxCoefficient);
        }

        private Vehicle CreateVehicle(string csvString)
        {
            var fields = CsvHelper.ParseCsvStringToFields(csvString);

            var id = int.Parse(fields[0]);
            var vehicleTypeId = int.Parse(fields[1]);
            var vehicleType = GetVehicleTypeById(vehicleTypeId);
            var model = fields[2];
            var licensePlat = fields[3];
            var weight = double.Parse(fields[4]);
            var year = int.Parse(fields[5]);
            var mileage = double.Parse(fields[6]);
            var color = (CarColor)Enum.Parse(typeof(CarColor), fields[7]);
            AbstractEngine engine = fields[8] switch
            {
                "Electrical" => new ElectricalEngine(double.Parse(fields[10])),
                "Gasoline" => new GasolineEngine(double.Parse(fields[9]), double.Parse(fields[10])),
                "Diesel" => new DieselEngine(double.Parse(fields[9]), double.Parse(fields[10])),
                _ => null
            };

            var tankCapacity = double.Parse(fields[11]);

            return new Vehicle(id, vehicleType, engine, model, licensePlat, weight, year, mileage, color, tankCapacity);
        }

        public void InsertVehicle(int index, Vehicle vehicle)
        {
            if (index < 0 || index > Vehicles.Count - 1)
                Vehicles.Add(vehicle);
            else
                Vehicles.Insert(index, vehicle);
        }

        public bool DeleteVehicle(int index)
        {
            if (index < 0 || Vehicles.Count < index)
            {
                return false;
            }

            Vehicles.RemoveAt(index);

            return true;
        }

        private double SumTotalProfit()
        {
            double totalProfit = 0d;
            foreach (var vehicle in Vehicles)
            {
                totalProfit += vehicle.GetTotalProfit();
            }

            return totalProfit;
        }

        public void Print()
        {
            Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
                              $"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");

            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine($"{vehicle.Id,-5}" +
                                  $"{vehicle.VehicleType.TypeName,-10}" +
                                  $"{vehicle.Model,-25}" +
                                  $"{vehicle.LicensePlate,-15}" +
                                  $"{vehicle.Weight,-15}" +
                                  $"{vehicle.YearIssue,-10}" +
                                  $"{vehicle.Mileage,-10}" +
                                  $"{vehicle.Color,-10}" +
                                  $"{vehicle.GetTotalIncome(),-10:0.00}" +
                                  $"{vehicle.GetCalcTaxPerMonth(),-10:0.00}" +
                                  $"{vehicle.GetTotalProfit(),-10:0.00}");
            }

            Console.WriteLine($"Total: {SumTotalProfit(),120:0.00}");
        }

        public void Sort(IComparer<Vehicle> comparator) => Vehicles.Sort(comparator);
    }
}
