using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamarinTimer
{
    public partial class TimerPage : ContentPage
    {
        public TimerPage()
        {
            InitializeComponent();
        }
        private void timer(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                time -= 1;
                _lblTime.Text = String.Format("{0}", time);
                if (time == 0.00)
                {
                    DisplayAlert("Süre Doldu", "Geri sayım süresi bitti!", "Ok");
                    return false;
                }

                return true;
            });
        }

        private void TimerStarterClicked(object sender,EventArgs e)
        {
            double time = double.Parse( _EntryTime.Text);
            timer(time);
        }
    }
}
