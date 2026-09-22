/*

   Copyright 2026 Esri

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
// Derived from the ArcGIS Pro SDK community sample
// Configuration/ProConfigWithAnimatedSplash. Namespace changed; behavior unmodified.
using System;
using System.Windows;
using System.Windows.Input;

namespace ArcPSLPro.UI
{
    public class OnMouseClick
    {
        public static readonly DependencyProperty MouseLeftClickProperty =
            DependencyProperty.RegisterAttached("MouseLeftClick", typeof(ICommand), typeof(OnMouseClick),
            new FrameworkPropertyMetadata(CallBack));

        public static void SetMouseLeftClick(DependencyObject sender, ICommand value) =>
            sender.SetValue(MouseLeftClickProperty, value);

        public static ICommand GetMouseLeftClick(DependencyObject sender) =>
            sender.GetValue(MouseLeftClickProperty) as ICommand;

        public static readonly DependencyProperty MouseEventParameterProperty =
            DependencyProperty.RegisterAttached("MouseEventParameter", typeof(object), typeof(OnMouseClick),
            new FrameworkPropertyMetadata((object)null, null));

        public static object GetMouseEventParameter(DependencyObject d) =>
            d.GetValue(MouseEventParameterProperty);

        public static void SetMouseEventParameter(DependencyObject d, object value) =>
            d.SetValue(MouseEventParameterProperty, value);

        private static void CallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is UIElement element)
            {
                if (e.OldValue != null)
                    element.RemoveHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Handler));
                if (e.NewValue != null)
                    element.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(Handler), true);
            }
        }

        private static void Handler(object sender, EventArgs e)
        {
            if (sender is UIElement element)
            {
                ICommand cmd = element.GetValue(MouseLeftClickProperty) as ICommand;
                if (cmd != null)
                {
                    object parameter = element.GetValue(MouseEventParameterProperty) ?? element;
                    if (cmd is RoutedCommand routedCmd)
                    {
                        if (routedCmd.CanExecute(parameter, element))
                            routedCmd.Execute(parameter, element);
                    }
                    else
                    {
                        if (cmd.CanExecute(parameter))
                            cmd.Execute(parameter);
                    }
                }
            }
        }
    }
}
