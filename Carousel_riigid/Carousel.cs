using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Carousel_riigid
{
    public class Carousel : CarouselPage
    {
        public Carousel()
        {
            for (int i = 1; i <= 5; i++)
            {
                var Page = new ContentPage
                {
                    TabIndex = i,                   
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new BoxView
                            {

                            },
                            
                            new Button
                            {
                                BackgroundColor= Color.DarkBlue,
                                TextColor= Color.White,
                            }
                        }
                    }
                };
                Children.Add(Page);
            }
            
            
        }
    }
}