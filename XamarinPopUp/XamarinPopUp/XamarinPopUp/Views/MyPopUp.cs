using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace XamarinPopUp.Views
{
    class MyPopUp : PopupPage
    {
        public MyPopUp()
        {
            Label _lblTitle = new Label()
            {
                Text = "Xamarin Popup Title",
                FontSize = 28,
                TextColor = Color.Red
            };

            StackLayout _stkTitle = new StackLayout
            {
                Children =
                {
                    _lblTitle
                }
            };

            Label _lblContent = new Label()
            {
                Text = "Xamarin Popup Content",
                FontSize = 24,
                TextColor = Color.Blue
            };

            StackLayout _stkContent = new StackLayout
            {
                Children =
                {
                    _lblContent
                }
            };

            Image _img = new Image()
            {
                Source= ImageSource.FromResource( "XamarinPopUp.Images.xamarin.jpg"),
                HeightRequest = 50,
                WidthRequest = 50
            };

            StackLayout _stk_Img = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    _img
                }
            };
            StackLayout _stk = new StackLayout
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Padding = new Thickness(10),
                Children =
                {
                    _stkTitle,
                    _stkContent,
                    _stk_Img
                }
            };

            Content = _stk;
        }
    }
}
