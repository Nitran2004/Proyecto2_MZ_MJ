using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
//using Xamarin.Forms;

namespace Proyecto2_MZ_MJ
{
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }
        
        private async void RegistrarButton_Clicked(object sender, EventArgs e)
        {
            string nombre = NombreEntry.Text;
            string correo = CorreoEntry.Text;
            string contrase�a = Contrase�aEntry.Text;

            // Comprueba si los campos est�n vac�os antes de realizar la validaci�n
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contrase�a))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Validaci�n personalizada para el campo Nombre
            if (!IsValidNombre(nombre))
            {
                await DisplayAlert("Error de validaci�n", "El campo Nombre no es v�lido.", "OK");
                return;
            }

            // Validaci�n de datos utilizando DataAnnotations
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                // La validaci�n ha fallado, muestra los mensajes de error
                foreach (var error in results)
                {
                    await DisplayAlert("Error de validaci�n", error.ErrorMessage, "OK");
                }
                return; // Sale de la funci�n si hay errores de validaci�n
            }

            // Si la validaci�n es exitosa, puedes continuar con el proceso de registro
            // Aqu� deber�as implementar la l�gica para registrar al usuario

            // Muestra un mensaje de �xito
            await DisplayAlert("Registro exitoso", "Usuario registrado correctamente", "OK");
            // Navega a la p�gina de inicio de sesi�n (LoginPage)
            await Navigation.PushAsync(new LoginPage());
        }
        
        
        private bool IsValidNombre(string nombre)
        {
            // Utiliza una expresi�n regular para verificar si el nombre contiene solo letras
            Regex regex = new Regex("^[a-zA-Z������������]+$");
            return regex.IsMatch(nombre);
        }
    }

    public class SignInPageModel
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo Electr�nico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del Correo Electr�nico no es v�lido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contrase�a es obligatorio.")]
        [MinLength(6, ErrorMessage = "La Contrase�a debe tener al menos 6 caracteres.")]
        public string Contrase�a { get; set; }
    }
}
