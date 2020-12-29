using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if(args.Length < 1)
            {
                Console.WriteLine("사용법 : {0} <Bind IP>", Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0];
            const int bindPort = 5425;
            TcpListener server = null;
            try
            {
                // IPEndPoint는 IP 통신에 필요한 IP 주소와 출입구(포트)를 나타냅니다.
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);

                server = new TcpListener(localAddress);

                // server 객체는 클라이언트가 TcpClient.Connect()를 호출하여 연결 요청해오기를 기다리기 시작합니다.
                // 연결 요청 수신 대기를 시작합니다.
                server.Start();

                Console.WriteLine("메아리 서버 시작...");

                while(true)
                {
                    // 클라이언트의 연결 요청을 수락합니다. 이 메소드는 TcpClient 객체를 반환합니다.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("클라이언트 접속 : {0} ", ((IPEndPoint)client.Client.RemoteEndPoint).ToString());

                    // 데이터를 주고받는데 사용하는 매개체인 NetworkStream을 가져옵니다.
                    NetworkStream stream = client.GetStream();

                    int length;
                    string data = null;
                    byte[] bytes = new byte[256];

                    while((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.Default.GetString(bytes, 0, length);
                        Console.WriteLine(String.Format("수신 : {0}", data));

                        byte[] msg = Encoding.Default.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine(String.Format("송신: {0}", data));
                    }

                    stream.Close();
                    client.Close();
                } catch (SocketException e)

            }
        }
    }
}
