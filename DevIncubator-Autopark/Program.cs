namespace DevIncubatorAutopark
{
    class Program
    {
        private static readonly string CsvFilesPath = @$"{Directory.GetCurrentDirectory()}\FileData\";
        public static void Main()
        {
            var orders = new OrderService($"{CsvFilesPath}orders.csv");
            orders.Print();
        }
    }
}