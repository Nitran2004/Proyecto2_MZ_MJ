using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2_MZ_MJ
{
    public class AppData
    {
        // Propiedades para los valores que deseas compartir entre páginas
        public string Valor1 { get; set; }
        public string Valor2 { get; set; }
        public string Valor3 { get; set; }

        // Singleton para acceder a una única instancia de AppData
        private static AppData instance;
        public static AppData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppData();
                }
                return instance;
            }
        }
    }

}
