namespace LabWork7
{
    internal class Program
    {
        private static string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите 1 число:");
                int a = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("Введите 2 число:");
                int b = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"Результат сложения = {a + b}");
                Console.WriteLine($"Результат вычитания = {a - b}");
                Console.WriteLine($"Результат умножения = {a * b}");
                Console.WriteLine($"Результат деления = {a / b}");
            }
            catch (FormatException ex)
            {
                LogError(ex);
                Console.WriteLine("Ошибка: вы ввели не целое число");
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException ex)
            {
                LogError(ex);
                Console.WriteLine("Ошибка: вы ввели слишком большое или маленькое числло");
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                LogError(ex);
                Console.WriteLine("Ошибка: на ноль делить нельзя");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Ошибка: что-то пошло не так");
                Console.WriteLine(ex.Message);
            }
        }

        static void LogError(Exception ex)
        {
            string logText = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().FullName} {ex.Message} {ex}\n";

            File.AppendAllText(logFile, logText);
        }
    }
}
