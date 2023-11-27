using System.Text.Json;

namespace Proyecto2_MZ_MJ;

public partial class MainPage2 : ContentPage
{
    private string filePath;


    public MainPage2()
    {
        InitializeComponent();

        filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "datos.txt");
    }

    private void OnOpenPageClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new FirstPage());
    }

    private void OnOpenPageClicked_2(object sender, EventArgs e)
    {
        Navigation.PushAsync(new SecondPage());
    }

    private void OnOpenPageClicked_3(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ThirdPage());
    }


    private async void Leer_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(filePath))
        {
            // Leer los datos del archivo
            string json = await File.ReadAllTextAsync(filePath);

            // Deserializar el JSON a un objeto de usuario
            var usuario = JsonSerializer.Deserialize<Usuario>(json);

            if (usuario != null)
            {
                await DisplayAlert("Datos", $"Nombre: {usuario.Nombre}\nCorreo: {usuario.Correo}", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "No se encontraron datos guardados", "Aceptar");
            }
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron datos guardados", "Aceptar");
        }
    }

    private async void Borrar_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(filePath))
        {
            // Borrar el archivo
            File.Delete(filePath);

            await DisplayAlert("Éxito", "Datos borrados correctamente", "Aceptar");
        }
        else
        {
            await DisplayAlert("Error", "No se encontraron datos guardados", "Aceptar");
        }
    }

    
    

}