using EccoleApp.MenuItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EccoleApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : MasterDetailPage
    {

        public List<MasterPageItems> MenuList { get; set; }

        public Home()
        {
            InitializeComponent();


            MenuList = new List<MasterPageItems>();
            //this are for android Icons you can download from android asset studio and include in Your Project Resources Folder
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            //agregar imágenes entre las comillas después de Icon = " "
            var page1 = new MasterPageItems() { Title = "Mi perfil", Icon = "", TargetType = typeof(Local) };
            var page2 = new MasterPageItems() { Title = "Administrar local", Icon = "", TargetType = typeof(Producto) };
            var page3 = new MasterPageItems() { Title = "Configuración", Icon = "", TargetType = typeof(Ubicacion) };
            var page4 = new MasterPageItems() { Title = "Ayuda", Icon = "", TargetType = typeof(RegistrarsePage) };
            var page5 = new MasterPageItems() { Title = "Otros", Icon = "", TargetType = typeof(RecuperarClavePage) }; 

            MenuList.Add(page1);
            MenuList.Add(page2);
            MenuList.Add(page3);
            MenuList.Add(page4);
            MenuList.Add(page5);


            // Setting our list to be ItemSource for ListView in MainPage.xaml
            //Configuración de su lista para que sea ItemSsource para ListView en MainPage.xaml
            navigationDrawerList.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page
            //Navegación inicial, esto puede ser usado para nuestra página de inicio.
            //investigar Binding
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Local)));
            this.BindingContext = new
            {
                Header = "",
                Image = "http://www3.hilton.com/resources/media/hi/GSPSCHF/en_US/img/shared/full_page_image_gallery/main/HH_food_22_675x359_FitToBoxSmallDimension_Center.jpg",
                //Footer = "         -------- Welcome To EccoleApp --------           "
                Footer = "Bienvenido a ÉccoleApp"
            };


        }
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItems)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }

}