using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace DigitalClock
{
    class ClockTicker1 : DependencyObject
    {
        // DependencyProperty 정의
        // 바인딩이 지속적으로 바인딩 소스에서 타깃을 정보를 전송하기 위해서는 소스가 바뀌었을때 타깃에게 통보할 특별한 메커니즘이 필요하다.
        // 하지만 소스가 의존 프로퍼티일 경우에 이 메커니즘은 자동으로 구현된다.
        public static DependencyProperty DateTimeProperty =
            DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ClockTicker1));

        // DependencyProperty을 CLR 프로퍼티로 노출
        public DateTime DateTime
        {
            set { SetValue(DateTimeProperty, value); }
            get { return (DateTime)GetValue(DateTimeProperty); }
        }

        // 생성자에서 timer를 설정
        public ClockTicker1()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimerOnTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        // SetValue(DateTime 프로퍼티를 자극하는)의 호출을 통해 외부에 영향을 미친다
        // -> 외부에 영향을 미친다는 뜻이 무엇일까?;;
        // DateTime 프로퍼티를 설정하는 타이머 이벤트 핸들러
        private void TimerOnTick(object sender, EventArgs e)
        {
            DateTime = DateTime.Now;
        }
    }
}
