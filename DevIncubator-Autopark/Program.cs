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
            var queue = new MyQueue<Vehicle>();

            //2
            Console.WriteLine("Очередь в автомойку");
            foreach (var vehicle in vehicles)
            {
                queue.Enqueue(vehicle);
                Console.WriteLine($"Авто {vehicle.Model} вошло в очередь");
            }

            //3
            Console.WriteLine("Вымытые авто");
            var sourceQueueLength = queue.Count;
            for (int i = 0; i < sourceQueueLength; i++)
            {
                var vehicle = queue.Dequeue();
                Console.WriteLine($"Авто {vehicle.Model} вымыто");
            }
        }
    }
}