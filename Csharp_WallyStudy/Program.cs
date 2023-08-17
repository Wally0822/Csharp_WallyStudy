using Csharp_WallyStudy.DataStructure;
using Csharp_WallyStudy.DesignPattern;

namespace Csharp_WallyStudy;

public class Program
{
    public static void Main(string[] args)
    {
        #region DataStrucrure Test
        //MyArrayDemo myArrayTest = new MyArrayDemo();
        //MyArrayDemo.Run();

        //myListDemo myListTest = new myListDemo();
        //myListDemo.Run();
        #endregion


        // 디자인 패턴이란 : 
        // 프로그램을 설계할 때 발생했던 문제점들을 객체 간의 상호 관계 등을 이용하여
        // 해결 할 수 있도록 하나의 '규약'형태로 만들어 놓은 것입니다
        #region DisgnPattern Test
        //SingletonTest.Run();

        FactoryPatternDemo.Run();

        //StrategyPattern.OrderRun();
        #endregion
    }
}