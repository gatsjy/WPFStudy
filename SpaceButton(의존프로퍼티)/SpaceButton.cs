using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SpaceButton_의존프로퍼티_
{
    class SpaceButton :Button
    {
        // 전통적인 .NET 방법 - private 필드와 public 프로퍼티
        string txt;

        public string Text
        {
            set
            {
                txt = value;
                Content = SpaceOutText(txt);
            }
            get
            {
                return txt;
            }
        }

        // DependencyProperty와 public 프로퍼티
        public static readonly DependencyProperty SpaceProperty;

        public int Space
        {
            set
            {
                SetValue(SpaceProperty, value);
            }
            get
            {
                return (int)GetValue(SpaceProperty);
            }
        }

        // 정적 생성자
        // static은 사전적으로 "정적"이라는 뜻을 갖고 있습니다. 움직이지 않는다는 뜻이지요. C#에서 static은
        // 메소드나 필드가 클래스의 인스턴스가 아닌 클래스 자체에 소속되도록 지정하는 한정자입니다.
        static SpaceButton()
        {
            // metadata의 정의
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.DefaultValue = 1;
            metadata.AffectsMeasure = true;
            // 종속성 속성의 값이 상속 되는지?
            metadata.Inherits = true;
            metadata.PropertyChangedCallback += OnSpacePropertyChanged;

            // DependencyProperty를 등록
            // 이거를 이해하려면 먼저 callback 메서드에 대한 세부적인 이해가 필요하다.
            SpaceProperty = DependencyProperty.Register("Space", typeof(int), typeof(SpaceButton), metadata, ValidDateSpaceValue);
        }

        // 값 검증을 위한 콜백(Callback)메소드
        static bool ValidDateSpaceValue(object obj)
        {
            int i = (int)obj;
            return i >= 0;
        }

        // 프로퍼티가 변경됐을 때의 콜백 메소드
        private static void OnSpacePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            SpaceButton btn = obj as SpaceButton;
            btn.Content = btn.SpaceOutText(btn.txt);
        }

        // 텍스트에 빈칸을 넣는 메소드
        private object SpaceOutText(string str)
        {
            if (str == null)
                return null;

            StringBuilder build = new StringBuilder();

            foreach (char ch in str)
                build.Append(ch + new string(' ', Space));

            return build.ToString();
        }
    }
}
