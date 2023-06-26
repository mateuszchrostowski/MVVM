using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_Kolory.ModelWidoku
{
    internal class PolecenieResetowania : ICommand
    {
        private KolorMW kolor;

        public PolecenieResetowania(KolorMW kolor)
        {
            this.kolor = kolor;
            kolor.PropertyChanged += kolor_PropertyChanged;
        }

        private void kolor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return kolor.R != 0 || kolor.G != 0 || kolor.B != 0;
        }

        public void Execute(object parameter)
        {
            kolor.R = 0;
            kolor.G = 0;
            kolor.B = 0;
        }
    }
}
