namespace DevIncubatorAutopark
{
    internal class OrderService
    {
        private List<string> _details;
        public Dictionary<string, int> Orders { get; private set; }

        public OrderService(string ordersFilePath)
        {
            _details = new List<string>();
            Orders = new Dictionary<string, int>();
            LoadOrders(ordersFilePath);
        }

        public void Print()
        {
            foreach (var (key, value) in Orders)
            {
                Console.WriteLine($"{key,-7}:{value,3}шт.");
            }
        }

        private void AddOrder(string detail)
        {
            if (Orders.ContainsKey(detail))
            {
                Orders[detail]++;
            }
            else
            {
                Orders.Add(detail, 1);
            }
        }

        private void LoadOrders(string csvPath)
        {
            try
            {
                var csvStrings = CsvHelper.ReadCsvStrings(csvPath);

                foreach (var str in csvStrings)
                {
                    var csvFields = CsvHelper.ParseCsvStringToFields(str);
                    foreach (var field in csvFields)
                    {
                        _details.Add(field);
                    }
                }

                foreach (var detail in _details)
                {
                    AddOrder(detail);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {csvPath} not found.");
            }
        }
    }
}
