using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Breakout
{
    public sealed partial class Paddle : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public Paddle()
        {
            this.InitializeComponent();

            Width = 100;
            Height = 20;

        }

        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        //move
        public void Move(double x)
        {
            //new paddle location
            LocationX = x - Width / 2;
            //move
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

    }
}
