using System.Diagnostics;

while (true)
{
#if DEBUG
    Debug.WriteLine("Введите первое число");
#else
    Trace.WriteLine("Введите первое число");
#endif
    Console.WriteLine("Введите первое число: ");

    string addend = Console.ReadLine();

    if (addend == "exit")
        break;
#if DEBUG
    Debug.WriteLine("Введите второе число");
#else
    Trace.WriteLine("Введите второе число");
#endif
    Console.WriteLine("Введите второе число: ");

    string summand = Console.ReadLine();

    if (Convert.ToString(summand) == "exit")
        break;

#if DEBUG
    Debug.WriteLine("Сложение чисел");
#else
    Trace.WriteLine("Сложение чисел");
#endif
    int sum = Convert.ToInt16(addend) + Convert.ToInt16(summand);

    Debug.WriteLine("Сумма чисел");
    Trace.WriteLine("Сумма чисел");
    Console.WriteLine($"Сумма чисел: {sum}");
   
}