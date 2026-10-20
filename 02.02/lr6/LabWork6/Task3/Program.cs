using System.Text;

FileStream? fileStream = null;
try
{
    fileStream = new FileStream("text.txt", FileMode.Open, FileAccess.Read);
    byte[] buffer = new byte[fileStream.Length];
    await fileStream.ReadAsync(buffer, 0, buffer.Length);
    string textFromFile = Encoding.Default.GetString(buffer);

    Console.WriteLine("Введите искуемый символ:");
    char targetChar = Convert.ToChar(Console.Read());

    int count = textFromFile.Count(c => c == targetChar);
    Console.WriteLine($"Количество буквы '{targetChar}' в файле: {count}");
}
catch (FileNotFoundException)
{
    Console.WriteLine("Файл не найден");
}
finally
{
    Console.WriteLine("Файловый поток закрыт");
    fileStream?.Close();
    fileStream?.Dispose();
}
