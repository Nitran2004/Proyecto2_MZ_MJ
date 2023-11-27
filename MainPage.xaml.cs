using System.Text.Json;

namespace Proyecto2_MZ_MJ;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void ReservarButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SignInPage());
    }

}



