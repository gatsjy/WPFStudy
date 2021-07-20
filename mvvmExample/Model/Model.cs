using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvmExample
{
    class Model : INotifyPropertyChanged
    {
        private string NAME_;

        public string NAME
        {
            get
            {
                return this.NAME_;
            }
            set
            {
                this.NAME_ = value;
                this.OnPropertyChanged("NAME");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                try
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
                catch
                {
                }
            }
        }
        
        public Model()
        {
        }
    }
}
