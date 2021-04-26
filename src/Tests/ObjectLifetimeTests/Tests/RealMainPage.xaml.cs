using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

#if LIFTED
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.System;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;
#endif

using ObjectLifetimeTests;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ObjectLifetimeTestsUI
{
    public sealed partial class RealMainPage : UserControl
    {
        private DispatcherQueue _dispatcherQueue;

        public RealMainPage()
        {
            this.InitializeComponent();
            _dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        }

        public IList<string> Errors { get; } = new ObservableCollection<string>();

        private async void Run(object sender, RoutedEventArgs e)
        {
            var samplePage = new ObjectLifetimePage();
            _host.Children.Add(samplePage);

            _progressRing.IsActive = true;
            _runButton.IsEnabled = false;

            var testCount = 0;
            var failedCount = 0;

            await Task.Run(() =>
            {
                var test = new ObjectLifetimeTestsRunner(_dispatcherQueue, samplePage.Root);
                var methods = test.GetType().GetMethods();

                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes(typeof(TestAttribute), false);
                    if (!attributes.Any())
                    {
                        continue;
                    }

                    Debug.WriteLine(method.Name);
                    testCount++;

                    try
                    {
                        method.Invoke(test, null);
                        Debug.WriteLine($"{method.Name} passed");
                    }
                    catch (Exception)
                    {
                        failedCount++;
                        _dispatcherQueue.TryEnqueue(() =>
                       {
                           Errors.Add($"{method.Name} failed");
                       });
                    }
                }
            });

            TestCountMessage = $"{testCount} tests";
            FailedCountMessage = $"{failedCount} failed";

            _progressRing.IsActive = false;
            _runButton.IsEnabled = true;
        }



        public string TestCountMessage
        {
            get { return (string)GetValue(TestCountMessageProperty); }
            set { SetValue(TestCountMessageProperty, value); }
        }
        public static readonly DependencyProperty TestCountMessageProperty =
            DependencyProperty.Register("TestCountMessage", typeof(string), typeof(RealMainPage), new PropertyMetadata(""));

        public string FailedCountMessage
        {
            get { return (string)GetValue(FailedCountMessageProperty); }
            set { SetValue(FailedCountMessageProperty, value); }
        }
        public static readonly DependencyProperty FailedCountMessageProperty =
            DependencyProperty.Register("FailedCountMessage", typeof(string), typeof(RealMainPage), new PropertyMetadata(""));



    }
}
