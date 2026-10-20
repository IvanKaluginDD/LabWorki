using System.Diagnostics;

namespace Task3
{
    internal class Program
    {
        static TraceSource ts = new TraceSource("Calculator")
        {
            Switch = new SourceSwitch("CalculatorSwitch") { Level = SourceLevels.Information }
        };

        static void Main(string[] args)
        {
            var ts = new TraceSource("Calculator")
            {
                Switch = new SourceSwitch("CalculatorSwitch") { Level = SourceLevels.Information }
            };

            ts.Listeners.Add(new TextWriterTraceListener("trace.log", "fileListener"));
            ts.Listeners.Add(new ConsoleTraceListener());

            ts.TraceInformation("информация");
            ts.TraceEvent(TraceEventType.Verbose, 0, "");
            ts.TraceEvent(TraceEventType.Warning, 1, "предупреждение");
            ts.TraceEvent(TraceEventType.Error, 2, "ошибка");

            Console.WriteLine("Введите 1 число:");
            int a = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Введите 2 число:");
            int b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine($"Результат сложения = {a + b}");
            Console.WriteLine($"Результат вычитания = {a - b}");
            Console.WriteLine($"Результат умножения = {a * b}");
            Console.WriteLine($"Результат деления = {a / b}");

            ts.Flush();
            ts.Close();
        }
    }
}
