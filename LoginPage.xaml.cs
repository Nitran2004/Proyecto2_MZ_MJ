namespace Proyecto2_MZ_MJ;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}


    private async void IniciarSesionButton_Clicked(object sender, EventArgs e)
    {
        // Realiza la l�gica de inicio de sesi�n aqu�

        // Si el inicio de sesi�n es exitoso, navega a la p�gina de ingreso de datos de usuario
        await Navigation.PushAsync(new MainPage2());
    }



}