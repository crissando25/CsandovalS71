using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq.Expressions;
using System.Runtime;

namespace CsandovalS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();

        }

        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario , string Contraseña )
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contraseña =?",usuario,Contraseña);
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "usirael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                 
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContraseña.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("ALERTA","Usuario/Contraseña Incorrectos","Cerrar");
                }

            }
            catch (Exception)
            {
                throw; 
            }
        
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        
        }
    }
}