using System;

namespace DelegateChains
{
    // Notify 대리자 선언
    delegate void Notify(string message);

    // Notify 대리자의 인스턴스 EventOccured를 가지는 클래스 Notifier 선언
    class Notifier
    {
        public Notify EventOccured;
    }

    class EventListener
    {
        private string name;
        public EventListener(string name)
        {
            this.name = name;
        }

        public void SomethingHappened(string message)
        {
            Console.WriteLine($"{name}.SomethingHappened : {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Notifier 생성
            Notifier notifier = new Notifier();
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");

            notifier.EventOccured += listener1.SomethingHappened;
            notifier.EventOccured += listener2.SomethingHappened;
            notifier.EventOccured += listener3.SomethingHappened;
            notifier.EventOccured("You've got mail.");

            Console.WriteLine();

            notifier.EventOccured -= listener2.SomethingHappened;
            notifier.EventOccured("Download complete");

            Console.WriteLine();

            notifier.EventOccured = new Notify(listener2.SomethingHappened)
                                  + new Notify(listener3.SomethingHappened);
            notifier.EventOccured("Nuclear launch detected");

            Console.WriteLine();

            Notify notify1 = new Notify(listener1.SomethingHappened);
            Notify notify2 = new Notify(listener2.SomethingHappened);

            notifier.EventOccured = (Notify)Delegate.Combine(notify1, notify2);
            notifier.EventOccured("Fire!!");

            Console.WriteLine();

            notifier.EventOccured =
                (Notify)Delegate.Remove(notifier.EventOccured, notify2);
            notifier.EventOccured("RPG!");
        }
    }
}
