namespace MVVM_Kolory.ModelWidoku
{
    using Model;
    using System.ComponentModel;
    using System.Windows.Input;

    internal class KolorMW : INotifyPropertyChanged
    {
        private Kolor model = PlikXml.Czytaj();

        public double R
        {
            get
            {
                return model.R;
            }
            set
            {
                model.R = value;
                onPropertyChanged(nameof(R));
            }
        }

        public double G
        {
            get
            {
                return model.G;
            }
            set
            {
                model.G = value;
                onPropertyChanged(nameof(G));
            }
        }

        public double B
        {
            get
            {
                return model.B;
            }
            set
            {
                model.B = value;
                onPropertyChanged(nameof(B));
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string nazwaWłasności)
        {
            if (PropertyChanged != null)
                PropertyChanged(
                    this,
                    new PropertyChangedEventArgs(nazwaWłasności));
        }
        #endregion

        #region Polecenie
        private ICommand resetuj;

        public ICommand Resetuj
        {
            get
            {
                if(resetuj == null)
                    resetuj = new PolecenieResetowania(this);
                return resetuj;
            }
        }
        #endregion
    }
}
