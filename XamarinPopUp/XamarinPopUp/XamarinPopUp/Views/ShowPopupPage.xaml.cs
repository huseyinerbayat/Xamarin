using Rg.Plugins.Popup.Extensions;
using System;

using Xamarin.Forms;

namespace XamarinPopUp.Views
{
    public partial class ShowPopupPage : ContentPage
    {
        public ShowPopupPage()
        {
            InitializeComponent();

            BackgroundColor = Color.White;

            Button _btnShowPopUp = new Button()
            {
                Text = "Popup Göster",
                TextColor = Color.Aqua,
                BackgroundColor = Color.Blue
            };
            _btnShowPopUp.Clicked += _btnShowPopUp_Clicked;
            StackLayout _stk = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    _btnShowPopUp
                }
            };
            this.Content = _stk;
        }

        private void _btnShowPopUp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new MyPopUp());
        }
    }
}
    