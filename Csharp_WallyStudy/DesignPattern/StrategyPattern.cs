using System.Security.Cryptography;

namespace Csharp_WallyStudy.DesignPattern;

public interface IDiscountStrategy
{
    double ApplyDiscount(double price);
}

public class NodiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price;
    }
}

public class TenPercentDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price * 0.9;
    }
}

public class FiftyPercentDiscountStrategy : IDiscountStrategy
{
    public double ApplyDiscount(double price)
    {
        return price * 0.5;
    }
}

public class Order
{
    private IDiscountStrategy _discountStrategy;
    public double Price { get; private set; }

    public Order(double price, IDiscountStrategy discountStrategy)
    {
        Price = price;
        _discountStrategy = discountStrategy;
    }

    public double GetFinalPrice()
    {
        return _discountStrategy.ApplyDiscount(Price);
    }
}

public class StrategyPattern
{
    public static void OrderRun()
    {
        var order1 = new Order(100, new NodiscountStrategy());
        Console.WriteLine($"Final price with no discount: {order1.GetFinalPrice()}");

        var order2 = new Order(100, new TenPercentDiscountStrategy());
        Console.WriteLine($"Final price with 10% discount: {order2.GetFinalPrice()}");

        var order3 = new Order(100, new FiftyPercentDiscountStrategy());
        Console.WriteLine($"Final price with 50% discount: {order3.GetFinalPrice()}");
    }
}