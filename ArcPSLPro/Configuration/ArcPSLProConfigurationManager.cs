using ArcGIS.Desktop.Framework.Contracts;
using ArcPSLPro.UI;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ArcPSLPro.Configuration
{
    internal class ArcPSLProConfigurationManager : ConfigurationManager
    {
        protected override string TitleBarText => "ArcPSL Pro";

        protected override ImageSource Icon =>
            new BitmapImage(new Uri(@"pack://application:,,,/ArcPSLPro;component/Images/favicon.ico"));

        protected override System.Windows.Window OnShowSplashScreen() => new SplashScreen();

        private StartPageViewModel _vm;

        protected override System.Windows.FrameworkElement OnShowStartPage()
        {
            _vm ??= new StartPageViewModel();
            return new StartPage { DataContext = _vm };
        }

        protected override System.Windows.FrameworkElement OnShowAboutPage() => new AboutPage();
    }
}
