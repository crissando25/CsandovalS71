using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CsandovalS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public SQLiteAsyncConnection conexion;
        public Registro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
        }
        private void btnIngresar_Clicked_1(object sender, EventArgs e, Entry txtContraseña)
        {
            try
            {
                var datos = new Estudiante
                {
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Contraseña = txtContraseña.Text
                };
                conexion.InsertAsync(datos);
                txtNombre.Text = " ";
                txtUsuario.Text = " ";
                txtContraseña.Text = " ";
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }
    }
}