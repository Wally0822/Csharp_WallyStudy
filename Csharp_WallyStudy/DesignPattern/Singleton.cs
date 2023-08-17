namespace Csharp_WallyStudy.DesignPattern;

public class BasicSingleton
{
#nullable disable
    private static BasicSingleton _instance;

    private BasicSingleton() { }

    public static BasicSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new BasicSingleton();
            }

            return _instance;
        }
    }
}

public class ThreadSafeSingleton
{
    private static ThreadSafeSingleton _instance;
    private static readonly object _lock = new object();

    private ThreadSafeSingleton() { }

    public static ThreadSafeSingleton Instance
    {
        get
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new ThreadSafeSingleton();
                    }
                }
            }

            return _instance;
        }
    }
}

public sealed class LazySingleton
{
    private static readonly Lazy<LazySingleton> lazyInstance = new Lazy<LazySingleton>(() => new LazySingleton());

    private LazySingleton() { }

    public static LazySingleton Instance
    {
        get
        {
            return lazyInstance.Value;
        }
    }
}

public class SingletonDemo
{
    public static void Run()
    {
        // Basic Singleton Test
        var basicSingleton1 = BasicSingleton.Instance;
        var basicSingleton2 = BasicSingleton.Instance;
        if (ReferenceEquals(basicSingleton1, basicSingleton2))
        {
            Console.WriteLine("BasicSingleton: The two instances are the same.");
        }
        else
        {
            Console.WriteLine("BasicSingleton: The two instances are different.");
        }

        // Thread Safe Singleton Test
        var threadSafeSingleton1 = ThreadSafeSingleton.Instance;
        var threadSafeSingleton2 = ThreadSafeSingleton.Instance;

        if (ReferenceEquals(threadSafeSingleton1, threadSafeSingleton2))
        {
            Console.WriteLine("ThreadSafeSingleton: The two instances are the same.");
        }
        else
        {
            Console.WriteLine("ThreadSafeSingleton: The two instances are different.");
        }

        // Lazy Singleton Test
        var lazySingleton1 = LazySingleton.Instance;
        var lazySingleton2 = LazySingleton.Instance;

        if (ReferenceEquals(lazySingleton1, lazySingleton2))
        {
            Console.WriteLine("LazySingleton: The two instances are the same.");
        }
        else
        {
            Console.WriteLine("LazySingleton: The two instances are different.");
        }
    }
}