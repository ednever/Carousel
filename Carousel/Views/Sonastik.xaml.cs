using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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
        StackLayout stUp = new StackLayout { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
        Entry entry, entry2;   

        string fileName = "Sonad.txt";
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);     
        public Sonastik()
        {
            Title = "Sõnastik";
            //File.WriteAllText(Path.Combine(folderPath, fileName), "eesti - english"); //при запуске в первый раз

            st = new StackLayout();
            for (int i = 0; i < ButtonsNames.Length; i++)
            {
                Button button = new Button { Text = ButtonsNames[i] };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            st.Children.Add(st1);
            st.Children.Insert(1, stUp);
            ScrollView scrollView = new ScrollView { Content = st };
            Content = scrollView;
        }

        void Tap_Tapped(object sender, EventArgs e)
        {
            //Удаление
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            st1.Children.Clear();
            stUp.Children.Clear();
            Button btn = (Button)sender;
            if (btn.Text == ButtonsNames[0]) //Просмотр, изменение, удаление слов
            {
                if (String.IsNullOrEmpty(fileName)) return;
                if (fileName != null)
                {
                    String[] Andmed = File.ReadAllLines(Path.Combine(folderPath, fileName));
                    for (int i = 0; i < Andmed.Length; i++)
                    {
                        var columns = Andmed[i].Split('-');
                        Label label = new Label { Text = columns[0] + " - " + columns[1] };
                        stUp.Children.Add(label);
                    }                 
                }
            }
            else if (btn.Text == ButtonsNames[1]) //Добавление слова
            {
                StackLayout st2 = new StackLayout 
                { 
                    Orientation = StackOrientation.Horizontal, 
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                entry = new Entry { WidthRequest = 175, HeightRequest = 25 };
                st2.Children.Add(entry);

                Label label = new Label { Text = " - ", FontSize = 50 };
                st2.Children.Add(label);

                entry2 = new Entry { WidthRequest = 175, HeightRequest = 25 };
                st2.Children.Add(entry2);
               
                Button button = new Button { Text = "Salvesta" };
                button.Clicked += Button_Clicked;
                st1.Children.Add(st2);
                st1.Children.Add(button);


                
            }
            else //Salvesta click
            {
                if (File.Exists(Path.Combine(folderPath, fileName)))
                {
                    File.AppendAllText(Path.Combine(folderPath, fileName), "\n" + entry.Text + " - " + entry2.Text);
                }
                st1.Children.Clear();
            }
        }
    }
}