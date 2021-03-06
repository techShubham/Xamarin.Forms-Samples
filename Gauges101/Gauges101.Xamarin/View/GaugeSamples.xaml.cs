﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Gauges101
{
    public partial class GaugeSamples : ContentPage
    {
        public GaugeSamples()
        {
            InitializeComponent();

            this.Title = "Gauges 101";

            BindingContext = new XmlRepository().GetSamples();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var sample = e.Item as Sample;
            await this.Navigation.PushAsync(GetSample(sample.SampleViewType));
        }

        private Page GetSample(int sampleViewType)
        {
            switch (sampleViewType)
            {
                case 0: return new GettingStarted();
                case 1: return new DisplayingValues();
                case 2: return new UsingRanges();
                case 3: return new AutomaticScaling();
                case 4: return new Direction();
                case 5: return new BulletGraph();
                case 6: return new CustomAnimation();
            }
            return null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (listView != null)
            {
                listView.SelectedItem = null;
            }
        }
    }
}
