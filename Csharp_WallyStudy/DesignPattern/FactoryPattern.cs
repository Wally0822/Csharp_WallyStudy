namespace Csharp_WallyStudy.DesignPattern;

// 객체를 사용하는 코드에서 객체 생성 부분을 떼어내 추상화한 패턴이자 
// 상속 관계에 있는 두 클래스에서 상위 클래스가 중요한 뼈대를 결정하고,
// 하위 클래스에서 객체 생성에 관한 구체적인 내용을 결정하는 패턴입니다.

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