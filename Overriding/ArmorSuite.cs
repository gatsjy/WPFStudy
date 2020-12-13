using System;
using System.Collections.Generic;
using System.Text;

// 내가 이 공부를 하는 목적? 찰스페졸드 wpf를 더욱 즐겁게 능률적으로 공부하기 위함이다.
namespace Overriding
{
    class ArmorSuite
    {
        // 메소드를 오버라이딩 하기 위해서는 한 가지 조건이 필요합니다.
        // 그것은 오버라이딩을 할 메소드가 virtual 키워드로 한정되어 있어야 한다는 것입니다.
        public virtual void Initialize()
        {
            Console.WriteLine("Armored");
        }
    }

    class IronMan : ArmorSuite
    {
        // 이미 Initialize() 메서드를 virtual로 선언해놨기 때문에 새롭게 정의하면 된다.
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Repulsor Rays Armed");
        }
    }

    class WarMachine : ArmorSuite
    {
        public override void Initialize()
        {
            base.Initialize();
            Console.WriteLine("Double-Barrel Cannons Armed");
            Console.WriteLine("Micro-Rocket Launcher Armed");
        }
    }
}
