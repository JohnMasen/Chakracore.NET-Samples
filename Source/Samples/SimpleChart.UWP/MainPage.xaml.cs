using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using SimpleChart.UWP.ViewModel;
using Microsoft.Graphics.Canvas.Effects;
using System;
using Microsoft.Graphics.Canvas;
using Windows.UI;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Graphics.Canvas.Geometry;
using System.Diagnostics;

namespace SimpleChart.UWP
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;
        CanvasPathBuilder builder;
        Color black = Color.FromArgb(255, 0, 0, 0);
        Matrix3x2 scale;
        //const int VALUE_COUNT = 200;
        float strokeSize;
        DataStrip data;
        MainViewModel main;
        public MainPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;
            Vm.IsPauseChanged += Vm_IsPauseChanged;
        }

        private void Vm_IsPauseChanged(object sender, bool e)
        {
            if (canvas.Paused!=e)
            {
                data = Vm.Data;
                main = Vm;
                canvas.Paused = e;
                
            }
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void canvas_CreateResources(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            

        }

        private void canvas_Update(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {
            main.NextStep();
            float step = 1f / data.Length;
            float XPosition = 0;
            builder = new CanvasPathBuilder(sender);
            builder.BeginFigure(Vector2.Zero);
            foreach (var value in data) 
            {
                builder.AddLine(new Vector2(XPosition, -value));
                XPosition += step;
            }

            builder.EndFigure(CanvasFigureLoop.Open);
        }

        private void canvas_DrawAnimated(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {

            args.DrawingSession.Transform = scale;
            args.DrawingSession.DrawGeometry(CanvasGeometry.CreatePath(builder),black,strokeSize);
        }

        Random rnd = new Random();
        private IEnumerable<float> getRandomValue(int count)
        {
            int index = 0;
            while (index<count)
            {
                index++;
                yield return (float)rnd.NextDouble()*2f-1f;
            }
        }

        private void Page_Unloaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            canvas.RemoveFromVisualTree();
            canvas = null;
        }

        

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        
        private void canvas_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            bool wasPaused = canvas.Paused;
            canvas.Paused = true;
            this.scale = Matrix3x2.CreateScale((float)e.NewSize.Width, (float)e.NewSize.Height);
            this.scale *= Matrix3x2.CreateTranslation(0, (float)e.NewSize.Height);
            strokeSize = 1 / (float)Math.Max(e.NewSize.Width, e.NewSize.Height);
            if (!wasPaused)
            {
                canvas.Paused = false;
            }
        }
    }
}
