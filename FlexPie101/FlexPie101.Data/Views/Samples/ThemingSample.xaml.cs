﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexPieDemo.Data.Chart;
using Xamarin.Forms;
using Xuni.Xamarin.ChartCore;
using Xuni.Xamarin.FlexPie;
using System.Reflection;
namespace FlexPieDemo.Data.Views.Samples
{
    public partial class ThemingSample
    {
        List<Color[]> listPalettes;
        public ThemingSample()
        {
            InitializeComponent();
            this.listPalettes = new List<Color[]>();
            this.flexPie.ItemsSource = PieChartSampleFactory.CreateEntiyList();
            foreach (var field in typeof(Palettes).GetRuntimeFields())
            {
                if (field.IsStatic && field.FieldType == typeof(Color[]))
                {
                    listPalettes.Add(field.GetValue(null) as Color[]);
                    this.pickerThemeing.Items.Add(field.Name);
                }
            }
            this.pickerThemeing.SelectedIndex = 0;
            this.pickerThemeing.SelectedIndexChanged += pickerThemeing_SelectedIndexChanged;
        }

        void pickerThemeing_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flexPie.Palette = this.listPalettes[this.pickerThemeing.SelectedIndex];
        }
    }
}
