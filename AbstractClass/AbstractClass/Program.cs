using System;

namespace AbstractClass
{
    // 추상클래스는 인터페이스와 달리 "구현"을 가질 수 있습니다.
    // 하지만 클래스와는 달리 인스턴스를 가질 수는 없습니다.
    // 추상클래스는 구현을 갖되 인스턴스는 만들지 못합니다.
    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            Console.WriteLine("AbstractBase.PrivateMethodA()");
        }

        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            PrivateMethodA();
        }
    }
    class Program
    {
        // 추상클래스는 일반 클래스가 가질 수 있는 구현과 더불어 추상 메소드를 가지고 있습니다.
        // 추상메소드는 추상 클래스를 사용하는 프로그래머가 그 기능을 정의하도록 강제하는 장치입니다.
        // "이 클래스는 직접 인스턴스화 하지 말고 파생 클래스를 만들어 사용하세요. 어떠한 메서드를 꼭 오버라이딩 해야합니다.
        // 하지만 추상 클래스를 이용한다면 위의 설명이 필요 없다. 추상 클래스와 추상 메소드 가체가 이런 설명을 담고 있으니까..
        // -> 컴퓨터가 알아서 컴파일 오류를 던진다.. (이것이 추상 클래스를 사용하는 이유이다)
        // 나는 아직 추상클래스를 사용하도록 만드는 설계를 해본 적이 없어서 이러한 설명이 마음에 와닿지는 않는다...
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived();
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
    }
}
