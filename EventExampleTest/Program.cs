using System;

namespace EventExampleTest
{
    class Program
    {
        delegate void MyDelegate(int a);

        class Market
        {
            public event MyDelegate CustomerEvent;

            public void BuySomething(int CustomerNo)
            {
                if (CustomerNo == 30)
                    CustomerEvent(CustomerNo);
            }
        }
        static void Congratulation(int CustomerNo)
        {
            Console.WriteLine($"축하합니다! {CustomerNo}번째 고객 이벤트에 당첨되셨습니다.");
        }
        static void Main(string[] args)
        {
            Market market = new Market();
            market.CustomerEvent += new MyDelegate(Congratulation);

            for (int customerNo = 0; customerNo < 100; customerNo += 10)
                market.BuySomething(customerNo);
        }
    }
}
