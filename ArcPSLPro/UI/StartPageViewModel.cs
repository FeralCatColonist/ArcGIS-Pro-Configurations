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
using ArcGIS.Desktop.Framework.Contracts;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace ArcPSLPro.UI
{
    internal class StartPageViewModel : PropertyChangedBase
    {
        private readonly Dictionary<StartPageNavPages, UserControl> _pages =
            new Dictionary<StartPageNavPages, UserControl>();

        public StartPageViewModel()
        {
            _pages[StartPageNavPages.Home] = new ProStartPageBody();
            _pages[StartPageNavPages.Resources] = new ProStartPageResources();
            ControlContent = _pages[StartPageNavPages.Home];
        }

        private ICommand _navigateCmd = null;
        public ICommand NavigationCommand
        {
            get
            {
                if (_navigateCmd == null)
                {
                    _navigateCmd = new RelayCommand(
                                     (param) => Navigate(param.ToString()), () => true, true);
                }
                return _navigateCmd;
            }
        }

        private System.Windows.FrameworkElement _controlContent = null;
        public System.Windows.FrameworkElement ControlContent
        {
            get { return _controlContent; }
            set
            {
                SetProperty(ref _controlContent, value, () => ControlContent);
            }
        }

        private StartPageNavPages _currentNavPage = StartPageNavPages.Home;

        public StartPageNavPages CurrentNavPage
        {
            get { return _currentNavPage; }
            set { SetProperty(ref _currentNavPage, value, () => CurrentNavPage); }
        }

        internal void Navigate(string navParam)
        {
            object result;
            System.Enum.TryParse(typeof(StartPageNavPages), navParam, out result);
            var navPage = (StartPageNavPages)result;

            if (CurrentNavPage != navPage)
            {
                if (navPage == StartPageNavPages.Settings)
                {
                    FrameworkApplication.OpenBackstage("esri_core_aboutTab");
                    return;
                }
                CurrentNavPage = navPage;
                this.ControlContent = _pages[navPage];
            }
        }
    }
}
