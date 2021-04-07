using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace TypeYourTitle2
{
    class TypeYourTitle : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TypeYourTitle());
        }
        protected override void OnTextInput(TextCompositionEventArgs args)
        {
            base.OnTextInput(args);
            // 백스페이스바만을 따로 처리하고 있다.
            // 그외의 경우에는 단순히 키보드에서 입력된 글자를 Title 프로퍼티 뒤에 덧붙이고 있다.
            if (args.Text == "\b" && Title.Length > 0)
                Title = Title.Substring(0, Title.Length - 1);
            else if (args.Text.Length > 0 && !Char.IsControl(args.Text[0]))
                Title += args.Text;
        }
    }
}
