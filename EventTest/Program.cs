using System;

namespace EventTest
{
    delegate void EventHandler(string message);

    class MyNotifier
    {
        // 이벤트는 대리자에 event 키워드로 수식해서 선언한 것에 불과합니다.
        // 그렇다면 왜 이벤트를 언어에 추가했을까요?
        // 이벤트가 대리자와 가장 크게 다른 점은 바로 이벤트는 외부에서 직접 사용할 수 없다는 데 있습니다.
        // 이벤트는 public으로 선언되어있어도 자신이 선언되어 있는 클래스의 외부에서는 호출이 불가능 합니다.
        public event EventHandler SomethingHappened;
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if(temp != 0 && temp % 3 ==0)
            {
                SomethingHappened(String.Format("{0} : 짝", number));
            }
        }
    }
    class Program
    {
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            MyNotifier notifier = new MyNotifier();
            notifier.SomethingHappened += new EventHandler(MyHandler);

            for(int i = 1; i < 30; i++)
            {
                notifier.DoSomething(i);
            }
        }
    }
}
