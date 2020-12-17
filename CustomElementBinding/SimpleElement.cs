using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CustomElementBinding
{
    class SimpleElement : FrameworkElement
    {
        // DependencyProperty 정의
        public static DependencyProperty NumberProperty;

        // 정적 생성자에 DependencyProperty 생성
        static SimpleElement()
        {
            NumberProperty =
                DependencyProperty.Register("Number", typeof(double), typeof(SimpleElement),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));
        }

        // DependencyProperty를 CLR 프로퍼티로 노출
        public double Number
        {
            set { SetValue(NumberProperty, value); }
            get { return (double)GetValue(NumberProperty); }
        }

        // MeasureOverride를 오버라이딩해 크기를 하드 코딩
        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(200, 50);
        }

        // Number 프로퍼티를 보여주는 
    }
}
