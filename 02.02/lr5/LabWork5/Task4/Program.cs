int calculateDivisionOnZero(int number)
{
    return number / 0;
}
int calculateDivisionOnTen(int number)
{
    calculateDivisionOnZero(number);
    return number / 10;
}
int calculateDivisionOnHundred(int number)
{
    calculateDivisionOnTen(number);
    return number / 100;
}
int calculate(int number, int secondNumber)
{
    calculateDivisionOnHundred(number);
    return number / secondNumber;
}

Console.WriteLine(calculate(100,2));

