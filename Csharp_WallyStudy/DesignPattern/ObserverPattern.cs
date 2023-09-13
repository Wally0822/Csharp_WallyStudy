namespace Csharp_WallyStudy.DesignPattern;

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

public class ConcreteSubject : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _state;

    public string State
    {
        get { return _state; }
        set
        {
            _state = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer) 
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach(var observer in _observers)
        {
            observer.Update(_state);
        }
    }
}

public interface IObserver
{
    void Update(string state);
}

public class ConcreteObserver 
{
}

public class ObserverPattern
{

}