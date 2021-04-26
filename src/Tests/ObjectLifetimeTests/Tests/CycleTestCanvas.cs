using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if LIFTED
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
#endif

namespace ObjectLifetimeTests
{
    public class CycleTestCanvas : Canvas
    {
        public CycleTestCanvas()
        {
        }
//#if !VSPROJ
        public void OnPointerEntered(object sender, PointerRoutedEventArgs args)
        {
        }
//#endif
        public static readonly DependencyProperty DP1Property
            = DependencyProperty.RegisterAttached("DP1", typeof(Control), typeof(CycleTestCanvas), null);

        public static readonly DependencyProperty DP2Property
            = DependencyProperty.RegisterAttached("DP2", typeof(Control), typeof(CycleTestCanvas), null);
    }
}
