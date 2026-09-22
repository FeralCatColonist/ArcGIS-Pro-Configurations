/*

   Copyright 2023 Esri

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       https://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.

   See the License for the specific language governing permissions and
   limitations under the License.

*/
using ArcGIS.Desktop.Framework;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ArcPSLPro.UI
{
    public partial class StartPage : UserControl
    {
        public StartPage()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                InitResources();
        }

        private void InitResources()
        {
            var isDark = FrameworkApplication.ApplicationTheme == ApplicationTheme.Dark ||
                         FrameworkApplication.ApplicationTheme == ApplicationTheme.HighContrast;

            var themePath = isDark
                ? @"pack://application:,,,/ArcPSLPro;component\Styles\DarkTheme.xaml"
                : @"pack://application:,,,/ArcPSLPro;component\Styles\LightTheme.xaml";
            Resources.BeginInit();
            Resources.MergedDictionaries.Add(new System.Windows.ResourceDictionary
            {
                Source = new Uri(themePath)
            });
            Resources.EndInit();

            var folder = isDark ? "DarkImages" : "Images";
            BackgroundBrush.ImageSource = new BitmapImage(
                new Uri($@"pack://application:,,,/ArcPSLPro;component/{folder}/background.jpg",
                        UriKind.RelativeOrAbsolute));
        }
    }
}
