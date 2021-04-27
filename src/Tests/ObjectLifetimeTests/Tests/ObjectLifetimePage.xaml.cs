﻿using System;
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
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
#endif

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ObjectLifetimeTests
{
    public sealed partial class ObjectLifetimePage : UserControl
    {
        public ObjectLifetimePage()
        {
            this.InitializeComponent();

            this.MoveCanvas = null;
            this._itemsControlLeakTest = null;
        }

        public Panel Root => this._root;
        
    }
}
