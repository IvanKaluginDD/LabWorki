using System.Text.RegularExpressions;

void CalculateDegree()
{
    Console.WriteLine("Введите число: ");
    float number = Convert.ToInt16(Console.ReadLine());
    Console.WriteLine("Введите степень: ");
    int power = Convert.ToInt16(Console.ReadLine());
    float result = 1;
    if (power >= 0)
    {
        for (int i = 0; i < power; i++)
            result *= number;
    }
    else
    {
        for (int i = power; i < 0; i++)
            result *= 1 / number;
    }

    Console.WriteLine($"Результат: {result:F3}");
}

CalculateDegree();
CheckPassword();

void CheckPassword()
{
    Console.WriteLine("Введите пароль: ");
    string? password = Console.ReadLine();
    string regex = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,30}$";

    bool isValid = Regex.IsMatch(password, regex);
    if (isValid == true)
        Console.WriteLine("Надежный пароль");
    else
        Console.WriteLine("Не надежный пароль");
}


