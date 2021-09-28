using PracticaExamen1.BLL;
using PracticaExamen1.DAL;
using PracticaExamen1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PracticaExamen1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ciudades C = new Ciudades();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = C;
        }
        public void Limpiar()
        {
            this.C = new Ciudades();
            this.DataContext = C;
        }
        
        private bool Validar()
        {
            bool esValido = true;
            if(TextCiudadesID.Text.Length == 0 || Convert.ToInt32(TextCiudadesID.Text) == 0)
            {
                //|| Convert.ToInt32(TextCiudadesID.Text) == null
                esValido = false;
                MessageBox.Show("Ingrese la ciudadID", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //Agregado
            //bool esValido = true;
            if(TextNombre.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Ingrese el nombre", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return esValido;
            //Fin agragado
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            var ciudad = CiudadesBLL.Buscar(Convert.ToInt32(TextCiudadesID.Text));
            if (ciudad != null)
                this.C = ciudad;
            else
                this.C = new Ciudades();
                //Funciono
            if (ciudad == null)
            {
                MessageBox.Show("vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }   
                //fin agregado

            this.DataContext = this.C;
        } //Listo

        private void Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        } // Listo

        private void Guardar(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CiudadesBLL.Guardar(C);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Error", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            /*
            if(TextCiudadesID.Text.Length == 0)
            {
                MessageBox.Show("Error", "Fallo",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                /*
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            */
            
        }

        private void Eliminar(object sender, RoutedEventArgs e)
        {
            if(TextCiudadesID.Text.Length == 0)
            {
                return;
            }

            if (CiudadesBLL.Eliminar(Convert.ToInt32(TextCiudadesID.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro elimininado", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            
        } //Listo
    }
}
