using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Carousel_riigid
{
    public partial class MainPage : ContentPage
    {
        string text = "Moskva:Venemaa;" + "London:Suurbritannia;" + "Stockholm:Rootsi;";
        Button corousel, uus_kart;
        Editor uus_linn, uus_riik;
        Label uus;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Riigid_pealinnad.txt");
        public MainPage()
        {
            File.WriteAllText(path, text);
            StackLayout stack = new StackLayout(); 
            corousel= new Button()
            {
                Text = "Pealinnad ja need riigid",
                BackgroundColor= Color.DarkOrange,  
            };
            uus = new Label()
            {
                Text = "Kirjuta uus pealinn ja riik",
                BackgroundColor= Color.DarkOrange
            };
            uus_linn = new Editor()
            {
                Placeholder = "Pealinn"
            };
            uus_riik = new Editor()
            {
                Placeholder = "Riik"
            };
            uus_kart = new Button()
            {
                Text = "Lisa uus kart",
                BackgroundColor= Color.DarkOrange
            };
            corousel.Clicked += Corousel_Clicked;
            stack.Children.Add( corousel );
            stack.Children.Add(uus);
            stack.Children.Add(uus_linn);
            stack.Children.Add(uus_riik);
            stack.Children.Add(uus_kart);
            uus_kart.Clicked += Uus_kart_Clicked;
            Content = stack;
        }
        string uus_tekst;
        private void Uus_kart_Clicked(object sender, EventArgs e)
        {
            uus_tekst = uus_linn.Text+":"+uus_riik.Text+";";
            File.AppendAllText(path, uus_tekst);
            uus_linn.Text = null;
            uus_riik.Text = null;
        }

        private async void Corousel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new Carousel(path)));
        }
    }
}
