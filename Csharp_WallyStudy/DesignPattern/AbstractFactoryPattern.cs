namespace Csharp_WallyStudy.DesignPattern;

public interface IProductA
{
    string GetName();
}

public interface IProductB
{
    string GetVariantName();
}

public class ConcreteProductA1 : IProductA
{
    public string GetName() => "Product A1";
}

public class ConcreteProductB1 : IProductB
{
    public string GetVariantName() => "Variant of Product B1";
}

public class ConcreteProductA2 : IProductA
{
    public string GetName() => "Product A2";
}

public class ConcreteProductB2 : IProductB
{
    public string GetVariantName() => "Variant of Product B2";
}

public interface IAbstractFactory
{
    IProductA CreateProductA();
    IProductB CreateProductB();
}

public class ConcreteFactory : IAbstractFactory
{
    public IProductA CreateProductA() => new ConcreteProductA1();
    public IProductB CreateProductB() => new ConcreteProductB1();
}

public class ConcreteFactory2 : IAbstractFactory
{
    public IProductA CreateProductA() => new ConcreteProductA1();
    public IProductB CreateProductB() => new ConcreteProductB2();
}
    

public class AbstractFactoryPatternDemo
{
    public static void Run()
    {
        IAbstractFactory factory1 = new ConcreteFactory();
        var productA1 = factory1.CreateProductA();
        var productB1 = factory1.CreateProductB();

        Console.WriteLine($"Created {productA1.GetName()} using ConcreteFactory");
        Console.WriteLine($"Created {productB1.GetVariantName()} using ConcreteFactory");

        IAbstractFactory factory2 = new ConcreteFactory();
        var productA2 = factory2.CreateProductA();
        var productB2 = factory2.CreateProductB();

        Console.WriteLine($"Created {productA2.GetName()} using ConcreteFactory2");
        Console.WriteLine($"Created {productB2.GetVariantName()} using ConcreteFactory2");
    }
}