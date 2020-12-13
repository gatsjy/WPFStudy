using System;

namespace Overriding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating ArmorSuite....");

            ArmorSuite armorSuite = new ArmorSuite();
            armorSuite.Initialize();

            Console.WriteLine("\nCreating IronMan");
            ArmorSuite ironMan = new IronMan();
            ironMan.Initialize();

            Console.WriteLine("\nCreating WarMachine");
            ArmorSuite warMachine = new WarMachine();
            warMachine.Initialize();
        }
    }
}
