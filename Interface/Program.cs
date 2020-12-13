using System;
using System.IO;

namespace Interface
{
    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }
        public void WriteLog(string message)
        {
            writer.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), message);
        }
    }

    class ClimeateMonitor
    {
        private ILogger logger;
        public ClimeateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while(true)
            {
                Console.Write("온도를 입력해주세요.:");
                string temperature = Console.ReadLine();
                if (temperature == "")
                    break;

                logger.WriteLog("현재 온도 : " + temperature);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //뭔가 스프링의 인터페이스와 비슷하게 돌아가지 않는가?
            //인터페이스로 만들면 어떠한 값이 들어와도 Logger를 구현한 값이 들어오면 작동하게 되어있다.
            //ClimeateMonitor monitor = new ClimeateMonitor(new FileLogger("MyLog.txt"));
            ClimeateMonitor monitor = new ClimeateMonitor(new ConsoleLogger());
            monitor.start();
        }
    }
}
