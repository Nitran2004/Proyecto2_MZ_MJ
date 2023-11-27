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
            string contraseña = ContraseñaEntry.Text;

            // Comprueba si los campos están vacíos antes de realizar la validación
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(contraseña))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Validación personalizada para el campo Nombre
            if (!IsValidNombre(nombre))
            {
                await DisplayAlert("Error de validación", "El campo Nombre no es válido.", "OK");
                return;
            }

            // Validación de datos utilizando DataAnnotations
            var context = new ValidationContext(this);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(this, context, results, true))
            {
                // La validación ha fallado, muestra los mensajes de error
                foreach (var error in results)
                {
                    await DisplayAlert("Error de validación", error.ErrorMessage, "OK");
                }
                return; // Sale de la función si hay errores de validación
            }

            // Si la validación es exitosa, puedes continuar con el proceso de registro
            // Aquí deberías implementar la lógica para registrar al usuario

            // Muestra un mensaje de éxito
            await DisplayAlert("Registro exitoso", "Usuario registrado correctamente", "OK");
            // Navega a la página de inicio de sesión (LoginPage)
            await Navigation.PushAsync(new LoginPage());
        }
        
        
        private bool IsValidNombre(string nombre)
        {
            // Utiliza una expresión regular para verificar si el nombre contiene solo letras
            Regex regex = new Regex("^[a-zA-ZáéíóúÁÉÍÓÚñÑ]+$");
            return regex.IsMatch(nombre);
        }
    }

    public class SignInPageModel
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo Electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del Correo Electrónico no es válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [MinLength(6, ErrorMessage = "La Contraseña debe tener al menos 6 caracteres.")]
        public string Contraseña { get; set; }
    }
}
