using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinMapApplication.Models;

namespace XamarinMapApplication.Views
{
    class MapPage :ContentPage
    {
        Map currentMap;
        public MapPage()
        {
            CreateMap();
        }

        public void CreateMap()
        {
            currentMap = new Map
            {
                HasScrollEnabled = true,
                HasZoomEnabled = true,
                MapType = MapType.Street,
            };

            
            currentMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(39.9032923, 32.6226825), Distance.FromMiles(100)));


            List<Location> locations =  LocationPickerPage.locations;
            foreach(var location in locations)
            {
                Pin newPin = new Pin
                {
                    Label = location.Name,
                    Position = new Position(location.Latitude, location.Longitude)
                };
                newPin.Clicked += NewPin_Clicked;
                currentMap.Pins.Add(newPin);
            }
            Content = currentMap;
        }

        private async void NewPin_Clicked(object sender, System.EventArgs e)
        {
            Pin selectedPin = ((Pin)sender);
            Location selectedLocation = FindSelectedLocation(selectedPin.Label);
            bool isOK = await DisplayAlert("Seçili Konum", selectedPin.Label +
                    " seçildi. Değişiklik yapmak istiyor musunuz?","Evet","Hayır");
            if (isOK)
            {
                LocationPickerPage.selectedLocation = selectedLocation;
                LocationPickerPage.isSelectedLocationChanged = true;
            }
            
            
        }
        private Location FindSelectedLocation(string locationName)
        {
            foreach (var valecenter in LocationPickerPage.locations)
            {
                if(valecenter.Name == locationName)
                {
                    return valecenter;
                }
            }
            return null;
        }
    }
}
