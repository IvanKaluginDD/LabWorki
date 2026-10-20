try
{
    Console.WriteLine("Введите ваш возраст");
    int age = Convert.ToInt16(Console.ReadLine());
    if (age < 0)
        throw new NegativeNumberException("Ошибка! Возраст не может быть меньше нуля");
    else if (age > 0 && age < 18)
        Console.WriteLine("Вы несовершеннолетний!");
    else
        Console.WriteLine("Вы совершеннолетний");
}
catch (NegativeNumberException ex)
{
    Console.WriteLine(ex.Message);
}
catch (FormatException)
{
    Console.WriteLine("Ошибка! Введен текст, а не число");
}
