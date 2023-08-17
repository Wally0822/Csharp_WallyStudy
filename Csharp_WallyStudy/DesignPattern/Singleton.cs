namespace Csharp_WallyStudy.DesignPattern;

// Singleton Pattern
// 하나의 클래스에 오직 하나의 인스턴스만 가지는 패턴
// 하나의 인스턴스를 만들어 놓고 해당 인스턴스를 다른 모듈들이 공유하며 사용하기 때문에
// 인스턴스를 생성할 때 드는 비용이 줄어드는 장점이 있다.
// 하지만, 의존성이 높아진다는 단점도 있다.

// 데이터 베이스 연결할 때 많이 사용하는 패턴이다.
// 

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