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
            var vehicles = collection.Vehicles;
            var stack = new MyStack<Vehicle>(vehicles.Count);

            //2
            Console.WriteLine("Въезд в гараж");
            foreach (var vehicle in vehicles)
            {
                stack.Push(vehicle);
                Console.WriteLine($"{vehicle.Model} заехал в гараж.");
            }

            //3
            Console.WriteLine("Выезд из гаража");
            while (stack.Count > 0)
            {
                var vehicle = stack.Pop();
                Console.WriteLine($"{vehicle.Model} выехал из гаража.");
            }
        }
    }
}