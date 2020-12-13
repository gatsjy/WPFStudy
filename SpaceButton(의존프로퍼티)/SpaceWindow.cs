using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SpaceButton_의존프로퍼티_
{
    class SpaceWindow : Window
    {
        // DependencyProperty와 프로퍼티
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
        static SpaceWindow()
        {
            // metadata의 정의
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.Inherits = true;

            // SpaceProperty에 소유자를 추가하고, metadata를 오버라이딩
            SpaceProperty = SpaceButton.SpaceProperty.AddOwner(typeof(SpaceWindow));
            SpaceProperty.OverrideMetadata(typeof(SpaceWindow), metadata);
        }
    }
}
