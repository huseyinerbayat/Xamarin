using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinMapApplication.Models;

namespace XamarinMapApplication.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPickerPage : ContentPage
    {
        public static List<Location> locations = new List<Location>();
        public static Location selectedLocation = new Location();
        public static bool isSelectedLocationChanged = false;
        public LocationPickerPage()
        {
            InitializeComponent();
            Title = "Picker ve Map ile Konum Seçimi";
            var _imgMapsGestureRecognizer = new TapGestureRecognizer();
            _imgMapsGestureRecognizer.Tapped += _imgMapsGestureRecognizer_Tapped; ;
            _imgMap.GestureRecognizers.Add(_imgMapsGestureRecognizer);

            AddLocations();
            SetLocations();

            _pickerLocation.SelectedIndexChanged += _pickerLocation_SelectedIndexChanged;
        }
        protected override void OnAppearing()
        {
            if (isSelectedLocationChanged)
            {
                _pickerLocation.SelectedItem = selectedLocation;
                isSelectedLocationChanged = false;
            }
            base.OnAppearing();
        }

        private void _pickerLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = ((Picker)sender);
            Location selectedValeCenter = (Location)picker.SelectedItem;
        }

        private void _imgMapsGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MapPage());
        }

        private void AddLocations()
        {
            locations.Add(new Location {
                Id = 1,
                Name = "Kızılay Avm",
                Latitude = 39.9215499,
                Longitude = 32.8512267
            });

            locations.Add(new Location
            {
                Id = 2,
                Name = "Ankamall",
                Latitude = 39.952085,
                Longitude = 32.8287233
            });
        }
        private void SetLocations()
        {
            _pickerLocation.BindingContext = locations;
        }

        private void _btnShowSelectedLocation_Clicked(object sender, EventArgs e)
        {
            Location selectedLocation = (Location)_pickerLocation.SelectedItem;
            DisplayAlert("Seçili Konum", "Konum Id: " + selectedLocation.Id + "\nKonum Adı: " +  selectedLocation.Name 
                    + "\nLatitude: "+ selectedLocation.Latitude + "\nLongitude: " + selectedLocation.Longitude  ,"OK");
        }
    }
}