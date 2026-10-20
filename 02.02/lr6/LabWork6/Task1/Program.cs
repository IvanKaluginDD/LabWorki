using NLog;


Logger logger = LogManager.GetCurrentClassLogger();

var config = new NLog.Config.LoggingConfiguration();
var logFile = new NLog.Targets.FileTarget("logFile")
{
    FileName = "errors.log"
};
config.AddRule(LogLevel.Error, LogLevel.Fatal, logFile);
LogManager.Configuration = config;

try
{
    Console.WriteLine("Напишите первое число:");
    int divisble = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("Напишите второе число:");
    int divider = Convert.ToInt16(Console.ReadLine());
    int divided = divisble / divider;
    Console.WriteLine($"Результат: {divided}");
}
catch (FormatException ex)
{
    Console.WriteLine("Ошибка! Введен текст, а не число");
    logger.Error(ex, "Пользователь ввел текст заместо числа");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Ошибка! Делить на 0 нельзя");
    logger.Error(ex, "Пользователь делит на 0");
}
catch (Exception ex)
{
    Console.WriteLine(ex.StackTrace);
    logger.Error(ex, "Непредвиденная ошибка");
}

