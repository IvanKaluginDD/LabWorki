using System.Diagnostics;

int CalculateDiscount(int price, double discountRate)
{
    Debug.Assert(price > 0);

    discountRate /= 100;

    int totalPrice = Convert.ToInt16(price - (price * (discountRate)));
    Debug.Assert(discountRate > 0 && discountRate < 1);
    Debug.Assert(totalPrice == price || totalPrice< price);
    return totalPrice;
}
Console.WriteLine(CalculateDiscount(-400,10));
