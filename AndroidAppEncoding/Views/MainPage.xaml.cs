using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Logic;

namespace AndroidAppEncoding.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void CipherButton_Clicked(object sender, EventArgs e)
        {
            if(!(CipherController.VerifyText(InputEditor.Text) || CipherController.VerifyCodeword(CodewordEditor.Text)))
            {
                await DisplayAlert("Error", "Input text and code word fields should be filled correctly!", "Return");
                return;
            }
            try
            {
                OutputEditor.Text = CipherController.GateControl(InputEditor.Text, CodewordEditor.Text, 1);
            }
            catch (Exception)
            {
                return;
            }

        }

        public async void DecipherButton_Clicked(object sender, EventArgs e)
        {
            if (!(CipherController.VerifyText(InputEditor.Text) || CipherController.VerifyCodeword(CodewordEditor.Text)))
            {
                await DisplayAlert("Error", "Input text and code word fields should be filled correctly!", "Return");
                return;
            }
            try
            {
                OutputEditor.Text = CipherController.GateControl(InputEditor.Text, CodewordEditor.Text, 2);
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}