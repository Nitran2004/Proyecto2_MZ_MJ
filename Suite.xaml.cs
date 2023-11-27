using System;
using System.IO;
using Microsoft.Maui.Controls;

namespace Proyecto2_MZ_MJ
{
    public partial class Suite : ContentPage
    {
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }

        private string filePath;

        public Suite()
        {
            InitializeComponent();

            // Obtener la ruta del archivo en el almacenamiento local
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.txt");

            // Leer los datos desde el archivo
            ReadDataFromFile();
        }

        public Suite(string valor1, string valor2, string valor3) : this()
        {
            Valor1 = valor1;
            Valor2 = valor2;
            Valor3 = valor3;
        }

        private void ReadDataFromFile()
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    Valor1 = reader.ReadLine();
                    Valor2 = reader.ReadLine();
                    Valor3 = reader.ReadLine();
                }
            }

            lblValor1.Text = "Nombre: " + Valor1;
            lblValor2.Text = "Capacidad: " + Valor2;
            lblValor3.Text = "dd/mm/aaaa: " + Valor3;
        }

        private void OnReadClicked(object sender, EventArgs e)
        {
            ReadDataFromFile();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            SaveDataToFile(Valor1, Valor2, Valor3);
        }

        private void OnDeleteClicked(object sender, EventArgs e)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                Valor1 = Valor2 = Valor3 = string.Empty;
                lblValor1.Text = lblValor2.Text = lblValor3.Text = string.Empty;
            }
        }

        private void SaveDataToFile(string valor1, string valor2, string valor3)
        {
            if (valor1 == null)
                valor1 = string.Empty;

            if (valor2 == null)
                valor2 = string.Empty;

            if (valor3 == null)
                valor3 = string.Empty;

            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                writer.WriteLine(valor1);
                writer.WriteLine(valor2);
                writer.WriteLine(valor3);
            }
        }


        private void UpdateLabels()
        {
            lblValor1.Text = "Nombre: ";
            lblValor2.Text = "Capacidad: ";
            lblValor3.Text = "dd/mm/aaaa: ";

            entryValor1.Text = Valor1;
            entryValor2.Text = Valor2;
            entryValor3.Text = Valor3;
        }

        private void OnModifyClicked(object sender, EventArgs e)
        {
            // Cuando se hace clic en "Modificar", actualiza los valores con los de las entradas
            Valor1 = entryValor1.Text;
            Valor2 = entryValor2.Text;
            Valor3 = entryValor3.Text;

            // Puedes guardar los valores actualizados en el archivo aquí si es necesario
            SaveDataToFile(Valor1, Valor2, Valor3);

            // Actualiza las etiquetas para reflejar los valores actualizados
            UpdateLabels();

            // Cuando se hace clic en "Modificar", actualiza los valores en la clase compartida o en el servicio
            string valor1 = entryValor1.Text;
            string valor2 = entryValor2.Text;
            string valor3 = entryValor3.Text;

            AppData.Instance.Valor1 = valor1;
            AppData.Instance.Valor2 = valor2;
            AppData.Instance.Valor3 = valor3;
        }
    }
}
