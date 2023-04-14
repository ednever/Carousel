using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Carousel.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = "Sõnastik";
            Label label= new Label { Text = "Yooooooo"};
            Content= label;
        }
    }
}