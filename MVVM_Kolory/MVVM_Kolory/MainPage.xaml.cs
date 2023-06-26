using MVVM_Kolory.Model;

namespace MVVM_Kolory;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        
    }

    
    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        try
        {            
            PlikXml.Zapisz(
                suwakR.Value,
                suwakG.Value,
                suwakB.Value);
        }
        catch (Exception exc)
        {
            Title = $"Błąd zapisu do pliku {exc.Message}";
        }
    }
}

