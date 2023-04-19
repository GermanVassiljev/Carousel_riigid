using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Carousel_riigid
{
    public partial class MainPage : ContentPage
    {
        Button corousel;
        public MainPage()
        {
            StackLayout stack = new StackLayout(); 
            corousel= new Button()
            {
                Text = "Pealinnad ja need riigid",
                BackgroundColor= Color.DarkOrange,  
            };
            corousel.Clicked += Corousel_Clicked;
            stack.Children.Add( corousel );
            Content= stack;
        }

        private async void Corousel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new Carousel()));
        }
    }
}
