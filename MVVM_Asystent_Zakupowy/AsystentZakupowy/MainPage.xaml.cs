using System.Globalization;

namespace AsystentZakupowy;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private decimal suma = 0;
	private decimal limit = 200;

	private IFormatProvider fp = new CultureInfo("pl-PL");

	private void btnDodajKwote_Clicked(object sender, EventArgs e)
	{
		try
		{
			string s = edKwota.Text;
			decimal kwota = decimal.Parse(s, fp);
			if (kwota < 0) throw new Exception("Kwota nie może być ujemna");
			if (suma + kwota > limit) throw new Exception("Przekroczenie limitu");
			suma += kwota;
			lbSuma.TextColor = Colors.Blue;
			lbSuma.Text = suma.ToString();
		}
		catch(Exception)
		{
			lbSuma.Text = "Błąd!";
            lbSuma.TextColor = Colors.Red;
        }
	}
}

