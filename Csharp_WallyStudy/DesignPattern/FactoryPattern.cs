namespace Csharp_WallyStudy.DesignPattern;

// Factory 패턴은 객체 생성 로직을 특정 클래스나 메서드에 위임하여,
// 요청에 따라 다른 객체를 반환한는 디자인 패턴

public interface IProduct
{
    string GetProductName();
}

public class ConcreteParoductA : IProduct
{
    public string GetProductName()
    {
        return "Product A";
    }
}

public class ConcreteProductB : IProduct
{
    public string GetProductName()
    {
        return "Product B";
    }
}

public class ProductFactory
{
    public IProduct CreateProduct(string productType)
    {
        switch (productType)
        {
            case "A":
                return new ConcreteParoductA();
            case "B":
                return new ConcreteProductB();
            default:
                throw new ArgumentException($"Product type {productType} not recognized.");
        }
    }
}

public abstract class Creator
{
    public abstract IProduct FactoryMethod();
}

public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteParoductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

public class FactoryPatternDemo
{
    public static void Run()
    {
        // PattenOne();

        PattenTwo();
    }

    private static void PattenOne()
    {
        ProductFactory factory = new ProductFactory();

        IProduct productA = factory.CreateProduct("A");
        Console.WriteLine(productA.GetProductName());

        IProduct productB = factory.CreateProduct("B");
        Console.WriteLine(productB.GetProductName());
    }

    private static void PattenTwo()
    {
        Creator creatorA = new ConcreteCreatorA();
        IProduct productA = creatorA.FactoryMethod();
        Console.WriteLine($"Created {productA.GetProductName()} using {creatorA.GetType().Name}");

        Creator creatorB = new ConcreteCreatorB();
        IProduct productB = creatorB.FactoryMethod();
        Console.WriteLine($"Created {productB.GetProductName()} using {creatorB.GetType().Name}");
    }
}