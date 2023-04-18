using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace Carousel.Views
{
    public partial class Sonastik : ContentPage
    {
        string[] ButtonsNames = new string[2] { "Sõnad", "Lisa sõna" };
        StackLayout st;
        StackLayout st1 = new StackLayout { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

        string fileName = "Sonad.txt";
        //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DataDirectory);
        

        public Sonastik()
        {
            st = new StackLayout();
            for (int i = 0; i < ButtonsNames.Length; i++)
            {
                Button button = new Button { Text = ButtonsNames[i] };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;

            }
            st.Children.Add(st1);
            ScrollView scrollView = new ScrollView { Content = st };
            Content = scrollView;
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            st1.Children.Clear();
            Button btn = (Button)sender;
            if (btn.Text == ButtonsNames[0]) //Просмотр слов
            {
                Loe_failist();



            }
            else if (btn.Text == ButtonsNames[1]) //Добавление слова
            {
                StackLayout st2 = new StackLayout 
                { 
                    Orientation = StackOrientation.Horizontal, 
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                for (int i = 0; i < 2; i++)
                {
                    Entry entry = new Entry { WidthRequest = 170, HeightRequest = 25 };
                    st2.Children.Add(entry);
                }
                Label label = new Label { Text = " - ", FontSize = 50 };
                st2.Children.Insert(1, label);
                Button button = new Button { Text = "Salvesta" };
                button.Clicked += Button_Clicked;
                st1.Children.Add(st2);
                st1.Children.Add(button);
                
            }
            else 
            {
                
                st1.Children.Clear();
                //if (st1.Children[0].)
                //{
                //    st1.IsVisible = false;
                //}
                //else
                //{

                //}
            }
        }
        void Loe_failist()
        {
            if (String.IsNullOrEmpty(fileName)) return;
            if (fileName != null)
            {
                //var currentPath = System.Environment.DataDirectory;
                //string filePath = Path.GetFullPath(fileName);
                //String[] Andmed = File.ReadAllLines(filePath); 
                
                //String[] Andmed = File.ReadAllLines(Path.Combine(folderPath, fileName));
                //for (int i = 0; i < Andmed.Length; i++)
                //{
                //    var columns = Andmed[i].Split('-');
                //    Label label = new Label { Text = columns[0] + " - " + columns[1] };
                //    st.Children.Insert(1 + i, label);
                //}

                
            }
        }
    }
}