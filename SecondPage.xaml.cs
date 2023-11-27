using System;
using System.IO;
using Microsoft.Maui.Controls;
using System.Text.Json;

namespace Proyecto2_MZ_MJ
{
    public partial class SecondPage : ContentPage
    {
        private string filePath;

        public SecondPage()
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
            if (File.Exists(filePath))
            {
                // Leer todos los datos desde el archivo
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length >= 8) // Asegurarse de que hay al menos 8 líneas de datos
                {
                    string nombre = lines[0];
                    string correo = lines[1];
                    string capacidad = lines[2];
                    string precio = lines[3];
                    string descripcion = lines[4];
                    bool disponible = bool.Parse(lines[5]);
                    string tipo = lines[6];
                    string vista = lines[7];

                    // Mostrar una alerta con los valores leídos
                    string mensaje = $"Nombre: {nombre}\nCorreo: {correo}\nCapacidad: {capacidad}\nPrecio: {precio}\nDescripción: {descripcion}\nDisponible: {disponible}\nTipo: {tipo}\nVista: {vista}";
                    await DisplayAlert("Datos", mensaje, "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "Los datos en el archivo no son suficientes", "Aceptar");
                }
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
