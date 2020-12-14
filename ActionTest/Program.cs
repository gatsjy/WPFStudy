using System;

namespace ActionTest
{
    class Program
    {
        // 14.4.2 Action 대리자
        // Action 대리자는 Func 대리자와 거의 똑같다. 차이점이라면 Action 대리자는 반환형식이 없다는 것 뿐이다.
        // Func와 달리 어떤 결과를 반환하는 것을 목적으로 하지 않고, 일련의 작업을 수행하는 것이 목적이다.
        static void Main(string[] args)
        {
            Action act1 = () => Console.WriteLine("Action()");
            act1();

            int result = 0;
            Action<int> act2 = (x) => result = x * x;

            act2(3);
            Console.WriteLine($"result : {result}");

            Action<double, double> act3 = (x, y) =>
            {
                double pi = x / y;
                Console.WriteLine($"Action<T1, T2>({x},{y}) : {pi}");
            };
            act3(22.0, 7.0);
        }
    }
}
