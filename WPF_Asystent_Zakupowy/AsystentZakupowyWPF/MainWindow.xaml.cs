using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsystentZakupowyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
                lbSuma.Foreground = Brushes.Blue;
                lbSuma.Content = suma.ToString();
            }
            catch (Exception)
            {
                lbSuma.Content = "Błąd!";
                lbSuma.Foreground = Brushes.Red;
            }
        }
    }
}
