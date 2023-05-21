using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CsandovalS7.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiantes;
        public ConsultaRegistro()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            ObtenerEstudiantes();
        }
               

        public async void ObtenerEstudiantes()
        {
            var ResulEstudiantes = await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiantes = new ObservableCollection<Estudiante>(ResulEstudiantes);
            listaEstudiantes.ItemsSource = tablaEstudiantes;
        }

        private void  listaEstudiantes_ItemSelected(Object sender,SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            var ItemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId);
            string nombre = objetoEstudiante.Nombre.ToString();
            string usuario = objetoEstudiante.Usuario.ToString();
            string Contraseña = objetoEstudiante.Contraseña.ToString();

           Navigation.PushAsync(new Elemento(id, nombre, usuario, Contraseña));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }

    
}