using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carousel.Views
{
    public partial class Mang : CarouselPage
    {
        StackLayout st;
        public Mang()
        {
            
            string fileName = "Sonad.txt";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            String[] Andmed = File.ReadAllLines(Path.Combine(folderPath, fileName));

            for (int i = 0; i < Andmed.Length; i++)
            {
                var columns = Andmed[i].Split('-');
                st = new StackLayout 
                {
                    Children = 
                    {
                        new Label
                        {
                            Text = columns[0] + " - " + columns[1],
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            FontSize = 40
                        },
                    }
                };
                var contentPage = new ContentPage
                {
                    Content = st
                };               
                Children.Add(contentPage);
            }
            this.BindingContextChanged += Mang_BindingContextChanged;
            

        }

        void Mang_BindingContextChanged(object sender, EventArgs e)
        {
            st.Children.Clear();
        }
    }
}