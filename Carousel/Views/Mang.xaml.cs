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
        String[] Andmed = File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Sonad.txt"));
        Dictionary<string,string> dict = new Dictionary<string,string>();
        public Mang()
        {
            Title = "Mäng";
            BackgroundColor = Color.White;
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            for (int i = 0; i < Andmed.Length; i++)
            {
                string[] columns = Andmed[i].Split('-');
                dict.Add(columns[0], columns[1]);
                Label label = new Label
                {
                    Text = columns[0],
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    FontSize = 40
                };
                label.GestureRecognizers.Add(tap);
                Frame frame = new Frame
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    Content = label,
                };               
                StackLayout st = new StackLayout { Children = {frame}, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
                ContentPage contentPage = new ContentPage { Content = st };               
                Children.Add(contentPage);
            }
        }
        void Tap_Tapped(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (dict.ContainsKey(lbl.Text))
            {
                lbl.Text = dict[lbl.Text];
            }
            else 
            {
                lbl.Text = dict.FirstOrDefault(x => x.Value == lbl.Text).Key;
            }
            
        }
    }
}