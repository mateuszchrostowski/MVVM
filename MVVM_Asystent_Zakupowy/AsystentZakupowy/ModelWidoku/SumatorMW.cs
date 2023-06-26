using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsystentZakupowy.ModelWidoku
{
    using Model;
    using System.ComponentModel;
    using System.Windows.Input;

    internal class SumatorMW : INotifyPropertyChanged
    {
        private Sumator model = new Sumator(0, 200);

        public decimal Suma
        {
            get => model.Suma;
        }

        private decimal kwota = 0;

        public decimal Kwota
        {
            get => kwota;
            set
            {
                kwota = value;
                onPropertyChanged(nameof(Kwota));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string nazwaWłasności)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
        }

        private ICommand dodaj;

        public ICommand Dodaj
        {
            get
            {
                if (dodaj == null)
                    dodaj = new RelayCommand(
                        this,
                        p =>
                        {
                            model.Dodaj(kwota);
                            if (PropertyChanged != null)
                            {
                                onPropertyChanged(nameof(Suma));
                                onPropertyChanged(nameof(Kwota));
                            }
                        },
                        P => model.CzyMożnaDodać(Kwota));
                return dodaj;
            }
        }
    }
}
