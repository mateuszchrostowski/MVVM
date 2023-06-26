using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace AsystentZakupowyUWP
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private decimal suma = 0;
        private decimal limit = 200;

        private IFormatProvider fp = new CultureInfo("pl-PL");

        private void btnDodajKwote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = edKwota.Text;
                decimal kwota = decimal.Parse(s, fp);
                if (kwota < 0) throw new Exception("Kwota nie może być ujemna");
                if (suma + kwota > limit) throw new Exception("Przekroczenie limitu");
                suma += kwota;
                lbSuma.Foreground = new SolidColorBrush(Colors.Blue);
                lbSuma.Text = suma.ToString();
            }
            catch (Exception)
            {
                lbSuma.Text = "Błąd!";
                lbSuma.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
