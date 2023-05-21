using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;

namespace CsandovalS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        private int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> RActualizar;
        IEnumerable<Estudiante> REliminar;

        public Elemento(int id, string nombre, string usuario, string Contraseña)
        {
            InitializeComponent();
            TxtId.Text = id.ToString();
            TxtUsuario.Text = nombre;
            TxtContraseña.Text= usuario;
            TxtUsuario.Text = usuario;
            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }

        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db,int id)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiantew where =id =?", id);
        }

        public static IEnumerable<Estudiante>Actulizzar(SQLiteConnection db, string  nombre,string usuario,string Contraseña,int id)
        {
            return db.Query<Estudiante>("UPDATE  Estudiantew Set Nombre=?, usuario=? , Contraseña=? where id=?", nombre,usuario,Contraseña,id);
        }

        private void btnActualizar_Clicked(Object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                RActualizar = Actulizzar(db, TxtNombre.Text, TxtUsuario.Text, TxtContraseña.Text, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro()); 
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnEliminar_Clicked(Object sender, EventArgs e)
        {

            try

            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                REliminar = Eliminar (db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

    }
}