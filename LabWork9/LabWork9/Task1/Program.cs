namespace Task1
{
    internal class Program
    {
        public static void ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                return;
            }
            using (var reader = new StreamReader(filePath))
            {
                Console.WriteLine(reader.ReadLineAsync());
            }
        }

        public static void WriteToFile(string filePath, string data)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                foreach (char c in data)
                {
                    writer.Write(c);
                }
                writer.WriteLineAsync(data);
            }
        }
        public static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            return n + Fibonacci(n - 1);
        }

        static void Main(string[] args)
        {
            string filePath = "data.txt";
            WriteToFile(filePath, "Some data to be written to the file");
            ReadFromFile(filePath);
            Console.WriteLine("Fibonacci Sequence:");
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Fib({i}) = {Fibonacci(i)}");
            }
        }
    }
}