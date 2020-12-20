using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentTemplateDemo
{
    public class Employee
    {
        // Private 필드
        string name;
        string face;
        DateTime birthdate;
        bool Lefthanded;

        // XAML에서 사용되는 인자 없는 생성자
        public Employee()
        {
        }

        // C# 코드에서 사용되는 인자를 가진 생성자
        public Employee(string name, string face, DateTime birthdate, bool lefthanded)
        {
            Name = name;
            Face = face;
            BirthDate = birthdate;
            Lefthanded = lefthanded;
        }

        // public 프로퍼티
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public string Face
        {
            set { face = value; }
            get { return face; }
        }
        public DateTime BirthDate
        {
            set { birthdate = value; }
            get { return birthdate; }
        }
        public bool LeftHanded
        {
            set { LeftHanded = value; }
            get { return Lefthanded; }
        }
    }
}
