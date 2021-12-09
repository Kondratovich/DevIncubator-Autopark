namespace DevIncubatorAutopark
{
    class Program
    {
        private static readonly string CsvFilesPath = @$"{Directory.GetCurrentDirectory()}\FileData\";
        public static void Main()
        {
            //1
            Collections collection = new Collections(
                $"{CsvFilesPath}rents.csv",
                $"{CsvFilesPath}vehicles.csv",
                $"{CsvFilesPath}types.csv");
            collection.Print();

            //2
            var vehicle = new Vehicle(8, collection.VehicleTypes[1], new GasolineEngine(2.2d, 40d), "Subaru Impreza", "7777 XX-7", 1700d, 2003, 27000, CarColor.Red, 60d);
            collection.InsertVehicle(-1, vehicle);

            //3
            collection.DeleteVehicle(1);
            collection.DeleteVehicle(4);

            //4
            collection.Print();

            //5
            collection.Sort(new VehicleComparer());

            //6
            collection.Print();
        }
    }
}