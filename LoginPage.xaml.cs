namespace Proyecto2_MZ_MJ;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}


    private async void IniciarSesionButton_Clicked(object sender, EventArgs e)
    {
        // Realiza la lógica de inicio de sesión aquí

        // Si el inicio de sesión es exitoso, navega a la página de ingreso de datos de usuario
        await Navigation.PushAsync(new MainPage2());
    }



}