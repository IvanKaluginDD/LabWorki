using System.Diagnostics;

namespace Task2
{
    internal class Program
    {
        private static string timingFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "timing.txt");
        private static string longFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "longFile.txt");
        static void Main(string[] args)
        {
            double TotalMsReadTxtFile = 0;
            double TotalMsGetApiData = 0;
            double TotalMsMathCalculation = 0;
            for (int i = 0; i < 3; i++)
            {
                Stopwatch stopWatch = new();
                stopWatch.Start();
                using (StreamReader sr = new StreamReader(longFile)) { 
                    while(sr.ReadLine() != null)
                    {
                        i += 1;
                        i -= 1;
                    }
                }
                stopWatch.Stop();
                Debug.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
                LogTiming("ReadTxtFile", stopWatch.Elapsed.TotalMilliseconds);
                TotalMsReadTxtFile += stopWatch.Elapsed.TotalMilliseconds;

                stopWatch.Start();
                using (var client = new HttpClient())
                {
                    var response = client.GetStringAsync("https://catfact.ninja");
                }
                stopWatch.Stop();
                Debug.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
                LogTiming("GetApiData", stopWatch.Elapsed.TotalMilliseconds);
                TotalMsGetApiData += stopWatch.Elapsed.TotalMilliseconds;

                stopWatch.Start();
                for (int j = 0; j < 300; j++)
                {
                    double result = Math.Sin(j) * Math.Cos(j);
                }
                stopWatch.Stop();
                Debug.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
                LogTiming("MathCalculation", stopWatch.Elapsed.TotalMilliseconds);
                TotalMsMathCalculation += stopWatch.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine($"Среднее время чтения файла равно {TotalMsReadTxtFile/3.0}ms");
            Console.WriteLine($"Среднее время получения информации по API равно {TotalMsGetApiData / 3.0}ms");
            Console.WriteLine($"Среднее время математических операций равно {TotalMsMathCalculation / 3.0}ms");
        }

        static void LogTiming(string operation, double milliSeconds)
        {
            string timingText = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Operation={operation} Elapsed={milliSeconds}ms\n";

            File.AppendAllText(timingFile, timingText);
        }
    }
}
