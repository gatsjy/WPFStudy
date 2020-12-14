using System;
using System.Runtime.CompilerServices;

namespace FuncTest
{
    // Func와 Action으로 더 간편하기 무명 함수 만들기
    // 익명메소드와 무명함수는 코드를 보다 간결하게 만들어주는 요소들입니다. 하지만 이들을 선언하기 전에 해야하는 작업을 생각해보라..
    // 대부분의 경우 단 하나의 익명 메소드나 무명함수를 만들기 위해 별개의 대리자를 선언해야한다..
    // Func 대리자는 결과를 반환하는 메소드를 참조하기 위해서
    // Action 대리자는 결과를 반환하지 않는 메소드를 참조합니다.
    class Program
    {
        // 14.4.1 Func 대리자
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10;
            Console.WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => x * 2;
            Console.WriteLine($"func2(4) : {func2(4)}");

            Func<double, double, double> func3 = (x, y)=>x / y;
            Console.WriteLine($"func3(22,7) : {func3(22, 7)}");
        }
    }
}
