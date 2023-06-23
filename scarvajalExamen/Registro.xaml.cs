using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.Internals.GIFBitmap;

namespace scarvajalExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        double costoCurso = 1500;
        double pagoMensual;
        string usuario;
        public Registro(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = "Usuario conectado: " + usuario;
            this.usuario = usuario;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //Una empresa privada se encarga de brindar cursos Online y necesita desarrollar una
            //aplicación móvil para registrar estudiantes, el costo del curso es de 1500, pero el
            //estudiante primero cancela una parte al momento de la inscripción y el resto se lo
            //dividen para 4 cuotas, pero acada cuota se le suma el 4 % por ciento del costo.
            double pagoInicial = Double.Parse(txtMontoInicial.Text);
            double pagoCuota = this.costoCurso - pagoInicial;
            double pagoInteres = pagoCuota * 0.04;
            pagoCuota = pagoCuota / 4 + pagoInteres;
            txtPagoMensual.Text = pagoCuota.ToString();
            this.pagoMensual = pagoCuota;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;            
            int edad = int.Parse(txtEdad.Text);
            string fecha = dpFecha.Date.ToString();
            string ciudad = pkCiudad.Items[pkCiudad.SelectedIndex];
            string pais = pkPais.Items[pkPais.SelectedIndex];
            double pagoInicial = double.Parse(txtMontoInicial.Text);
            double pagoMensual = this.pagoMensual;

            Navigation.PushAsync(new Resumen(this.usuario, nombre, apellido, edad, fecha, ciudad, pais, pagoInicial, pagoMensual));

        }

        private void txtMontoInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            double pagoInicial = Double.Parse(txtMontoInicial.Text);

            if (pagoInicial > this.costoCurso)
            {
                DisplayAlert("Alerta", "No puede exeder el valor del curso $1500", "Ok");                
            }
        }
    }
}