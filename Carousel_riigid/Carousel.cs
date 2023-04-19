using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;

namespace Carousel_riigid
{
    public class Carousel : CarouselPage
    {
        public Carousel()
        {
            string filename = "Riigid_pealinnad.txt";
            string text = "Moskva;Venemaa\n" + "London;Suurbritannia\n" + "Stockholm;Rootsi";

            // Get the path to the Documents folder for the app
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);

            // Combine the path with the filename to create the full file path
            string filePath = Path.Combine(path, filename);

            // Write the text to the file
            File.WriteAllText(path, text);
            var pealinnad = new Dictionary<int, string>()
            {
                {1,"Moskva"},
                { 2,"Stockholm"},
                { 3, "London" }
            };
            var riigid = new Dictionary<int, string>()
            {
                {1, "Venemaa" },
                { 2, "Rootsi" },
                {3, "Suurbritannia" }
            };
            for (int i = 1; i <= 3; i++)
            {
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
                                Text = File.ReadAllText(path)
                            },
                            new Editor
                            {
                                Placeholder = "Riig"
                            },
                            new Button
                            {
                                BackgroundColor = Color.DarkOrange,                                
                            }                            
                        }
                    }
                };
                Children.Add(Page);
                var editor = ((StackLayout)Page.Content).Children[1] as Editor;
                
            }

            
            
        }
    }
}