using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Breakout
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //canvas size
        public static double CanvasWidth;
        public static double CanvasHeight;

        //game
        Game game;

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);

            //used in ball and paddle
            CanvasWidth = MyCanvas.Width;
            CanvasHeight = MyCanvas.Height;

            //create a new game

            game = new Game(MyCanvas);
            game.StartGame();
        }

        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint point = e.GetCurrentPoint(this);
            //move paddle...x

            game.paddle.Move(point.Position.X);
        }
    }
}
