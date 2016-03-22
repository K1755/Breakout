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
    public sealed partial class Ball : UserControl
    {
        //location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        //speed
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public Ball()
        {
            this.InitializeComponent();

            Width = 15;
            Height = 15;
            SpeedX = -15; //random 
            SpeedY = -15;
        }

        //return balls rect
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        //move ball
        public void Move()
        {
            //change in x
            LocationX = LocationX + SpeedX;
            if (LocationX < 0) //left
            {
                LocationX = 0;
                SpeedX *= -1;
            }
            else if (LocationX + Width > MainPage.CanvasWidth) //right
            {
                LocationX = MainPage.CanvasWidth - Width;
                SpeedX *= -1;
            }
            //change in y
            LocationY = LocationY + SpeedY;
            if (LocationY < 0) // up
            {
                LocationY = 0;
                SpeedY *= -1;
            }
            // move ball in canvas
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        //ball speed
        public void SetSpeed(Double hitPercent)
        {
            SpeedX = hitPercent * 10; //-5 <> 5
            SpeedY *= -1;
        }
    }
}
