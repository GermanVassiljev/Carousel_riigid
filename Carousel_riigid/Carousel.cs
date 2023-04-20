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
        string text = "Moskva:Venemaa;" + "London:Suurbritannia;" + "Stockholm:Rootsi;";
        string filename = "Riigid_pealinnad.txt";
        public Carousel()
        {

            // Get the path to the Documents folder for the app
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

            // Combine the path with the filename to create the full file path
            string filePath = Path.Combine(path, filename);

            // Write the text to the file
            File.WriteAllText(path, text);

            string dir_FilePath = Path.Combine(path, filename);
            string dir_Text = File.ReadAllText(path);
            string[] dir = dir_Text.Split(';');
            int length = dir.Length;
            string direct;
            string[] linnad_riigid;
            //for (int i = 0; i < dir.Length; i++)
            //{
            //    direct = dir[i];
            //    //linnad_riigid.SetValue(direct.Split(':'), i);
            //    linnad_riigid = direct.Split(':');
            //}            




            for (int i = 0; i < length - 1 ; i++)
            {
                string rnd = dir[i];
                linnad_riigid = rnd.Split(':');
                var Page = new ContentPage
                {
                    TabIndex = i,
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                FontSize= 20,
                                Text = linnad_riigid[0]
                            },
                            new Button
                            {
                                BackgroundColor = Color.DarkOrange,
                            }
                        }
                    }

                };
                Children.Add(Page);
                //var editor = ((StackLayout)Page.Content).Children[1] as Editor;

            }





        }
        private string ReadLine(int arv_leht, string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                for (int i = 1; i <= arv_leht; i++)
                {
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    if (i == arv_leht)
                    {
                        return reader.ReadLine();
                    }
                    else
                    {
                        reader.ReadLine(); // skip this line and continue reading
                    }
                }
                return "";
            }
        }
    }
}