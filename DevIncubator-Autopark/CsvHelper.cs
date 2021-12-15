namespace DevIncubatorAutopark
{
    internal static class CsvHelper
    {
        public static List<String> ParseCsvStringToFields(string csvString)
        {
            var splitStrings = csvString.Split(",\"");
            var fields = new List<string>();
            if (splitStrings.Length == 0)
            {
                fields.AddRange(csvString.Split(','));
            }
            else
            {
                for (int i = 0; i < splitStrings.Length; i++)
                {
                    if (splitStrings[i].Contains('\"'))
                    {
                        fields.Add(splitStrings[i].Substring(0, splitStrings[i].IndexOf('\"')));
                        splitStrings[i] = splitStrings[i].Remove(0, splitStrings[i].IndexOf('\"') + 1);
                        if (!String.IsNullOrEmpty(splitStrings[i])){
                            fields.AddRange(splitStrings[i].Substring(1).Split(','));
                        }
                        continue;
                    }
                    fields.AddRange(splitStrings[i].Split(','));
                }
            }
            return fields;
        }

        public static List<String> ReadCsvStrings(string path)
        {
            var csvStrings = new List<String>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        csvStrings.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return csvStrings;
        }
    }
}
