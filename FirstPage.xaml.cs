using System;
using System.IO;
using Microsoft.Maui.Controls;
using System.Text.Json;

namespace Proyecto2_MZ_MJ
{
    public partial class FirstPage : ContentPage
    {
        private string filePath;

        public FirstPage()
        {
            InitializeComponent();
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");
        }

        private void OnOpenPageClicked(object sender, EventArgs e)
        {
            // ...
        }


        private void SaveDataToFile(string nombre, string correo, string capacidad, string precio, string descripcion, bool disponible, string tipo, string vista)
        {
            // Crear o sobrescribir el archivo de datos
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(nombre);
                writer.WriteLine(correo);
                writer.WriteLine(capacidad);
                writer.WriteLine(precio);
                writer.WriteLine(descripcion);
                writer.WriteLine(disponible);
                writer.WriteLine(tipo);
                writer.WriteLine(vista);
            }
        }



        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            // Obtener los valores ingresados por el usuario
            string nombre = txtNombre.Text;
            string correo = txtCorreo.Text;
            string capacidad = txtCapacidad.Text;
            string precio = txtPrecio.Text;
            string descripcion = txtDescripcion.Text;
            bool disponible = switchDisponible.IsToggled;
            string tipo = pickerTipo.SelectedItem?.ToString();
            string vista = txtVista.Text;

            // Llamar a SaveDataToFile para guardar todos los valores
            SaveDataToFile(nombre, correo, capacidad, precio, descripcion, disponible, tipo, vista);

            // Mostrar una alerta con los valores guardados
            string mensaje = $"Nombre: {nombre}\nCorreo: {correo}\nCapacidad: {capacidad}\nPrecio: {precio}\nDescripción: {descripcion}\nDisponible: {disponible}\nTipo: {tipo}\nVista: {vista}";
            await DisplayAlert("Datos ingresados", mensaje, "Aceptar");
        }



        private async void OnLeerClicked(object sender, EventArgs e)
        {
            // JSON de ejemplo (ajusta esto según tus necesidades)
            string jsonEjemplo = "{\"Nombre\":\"EjemploNombre\",\"Correo\":\"ejemplo@correo.com\"}";

            // Deserializa el JSON de ejemplo en un objeto de Usuario
            var usuario = JsonSerializer.Deserialize<Usuario>(jsonEjemplo);

            if (usuario != null)
            {
                await DisplayAlert("Datos", $"Nombre: {usuario.Nombre}\nCorreo: {usuario.Correo}", "Aceptar");
            }
            else
            {
                await DisplayAlert("Error", "No se encontraron datos guardados", "Aceptar");
            }
        }


        private async void OnBorrarClicked(object sender, EventArgs e)
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
}
