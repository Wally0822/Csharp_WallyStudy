namespace Csharp_WallyStudy.DesignPattern;

// 의존성 주입 원칙
// 상위 모듈은 하위 모듈에서 어떠한 것도 가져오지 않아야 합니다.
// 둘다 추상화에 의존해야 하며,
// 추상화는 세부사항에 의존하지 말아야 합니다.

public interface ILogger
{
    void Log(string message);
}

public class SingletonLogger : ILogger
{
#nullable disable
    private static SingletonLogger _instance;
    private static readonly object _lock = new object();

    private SingletonLogger() { }

    public static SingletonLogger Instance
    {
        get
        {
            if(_instance == null)
            {
                lock(_lock)
                {
                    _instance = new SingletonLogger();
                }
            }
            return _instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class Servise
{
    private readonly ILogger _logger;

    public Servise(ILogger logger)
    {
        _logger = logger;
    }

    public void DoWork()
    {
        _logger.Log($"Service is working");
    }
}

public class InjectableSinleton
{
    public static void Run()
    {
        Servise service = new Servise(SingletonLogger.Instance);
        service.DoWork();
    }
}