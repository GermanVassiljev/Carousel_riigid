using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using System.Runtime.InteropServices.ComTypes;

namespace Carousel_riigid
{
    public class Carousel : CarouselPage
    {       
        string[] dir;
        string[] linnad_riigid;
        public Carousel(string path)
        {           

            string dir_FilePath = Path.Combine(path, "Riigid_pealinnad.txt");
            string dir_Text = File.ReadAllText(path);
            dir = dir_Text.Split(';');
            int length = dir.Length;
            string direct;

            

            for (int i = 0; i < length - 1 ; i++)
            {
                string rnd = dir[i];
                linnad_riigid = rnd.Split(':');
                var Page = new ContentPage
                {
                    Content = new StackLayout
                    {
                        TabIndex= i,
                        Children =
                        {                            
                            new Label
                            {
                                FontSize= 20,
                                Text = linnad_riigid[0],
                                BackgroundColor= Color.DarkOrange,
                                TabIndex= i
                            }
                        }
                    }

                };
                Children.Add(Page);
                var lbl = ((StackLayout)Page.Content).Children[0] as Label;
                var tap = new TapGestureRecognizer();
                lbl.GestureRecognizers.Add(tap);
                tap.Tapped += Tap_Tapped;

            }






        }
        bool OnOff = true;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (OnOff)
            {
                var lbl = sender as Label;
                string Tekst_on = dir[lbl.TabIndex];
                linnad_riigid = Tekst_on.Split(':');
                lbl.Text += " - " + linnad_riigid[1];
                OnOff= false;
            }
            else
            {
                var lbl = sender as Label;
                string Tekst_on = dir[lbl.TabIndex];
                linnad_riigid = Tekst_on.Split(':');
                lbl.Text = linnad_riigid[0];
                OnOff= true;
            }
            
        }
    }
}