using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Amtgard_Pell_a_thon
{
    public partial class MainPage : ContentPage
    {
        bool running = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnStartStop_Clicked(object sender, EventArgs e)
        {
            if(!running)
            {
                //start running
                running = true;
                txtInterval.IsReadOnly = true;
                btnStartStop.Text = "Stop";

                Random callout = new Random();

                Device.StartTimer(TimeSpan.FromSeconds(int.Parse(txtInterval.Text)), () =>
                {
                    // Do something

                    if (running)
                    {
                        var nextCallout = callout.Next(1, 8);

                        lblLastCallout.Text = nextCallout.ToString();

                        TextToSpeech.SpeakAsync(nextCallout.ToString());
                    }

                    return running; // True = Repeat again, False = Stop the timer
                });               
                
            }
            else
            {
                //stop running
                running = false;
                txtInterval.IsReadOnly = false;
                btnStartStop.Text = "Start";
            }
        }
    }
}
