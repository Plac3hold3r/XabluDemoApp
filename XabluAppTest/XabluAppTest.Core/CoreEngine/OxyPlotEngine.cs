using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace XabluAppTest.Core.CoreEngine
{
    public static class OxyPlotEngine
    {

        public static PlotModel GetModel()
        {

            //var plotModel = new PlotModel { Title = "OxyPlot Demo" };

            var plotModel = new PlotModel
            {
                LegendOrientation = LegendOrientation.Vertical,
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                //Title = new CreditConverter().Convert(noon, typeof(string), null, culture) + " - 12:00",
                PlotAreaBorderThickness = new OxyThickness(10),
                PlotAreaBorderColor = OxyColor.FromAColor(0, OxyColor.FromRgb(255, 255, 255))
            };


            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                IsZoomEnabled = false,
                IsPanEnabled = false,
                Minimum = 0,
                Maximum = 24,
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                //Maximum = 5,
                //Minimum = -5,
                IsZoomEnabled = false,
                IsPanEnabled = false,
            });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerFill = OxyColor.FromArgb(255, 186, 0, 2),
                MarkerStroke = OxyColor.FromArgb(255, 186, 0, 2),
                Color = OxyColor.FromArgb(255, 186, 0, 2)
            };

            series1.Points.Add(new DataPoint(0.0, 0.0));
            series1.Points.Add(new DataPoint(1.0, 0.0));
            series1.Points.Add(new DataPoint(2.0, 0.5));
            series1.Points.Add(new DataPoint(3.0, 1.5));
            series1.Points.Add(new DataPoint(4.0, 0.5));
            series1.Points.Add(new DataPoint(5.0, 1.2));
            series1.Points.Add(new DataPoint(6.0, 0.0));

            //series1.Points.Add(new DataPoint(0.0, 6.0));
            //series1.Points.Add(new DataPoint(1.4, 2.1));
            //series1.Points.Add(new DataPoint(2.0, 4.2));
            //series1.Points.Add(new DataPoint(3.3, 2.3));
            //series1.Points.Add(new DataPoint(4.7, 7.4));
            //series1.Points.Add(new DataPoint(6.0, 6.2));
            //series1.Points.Add(new DataPoint(8.9, 8.9));

            var series2 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerFill = OxyColor.FromArgb(255, 255, 204, 63),
                MarkerStroke = OxyColor.FromArgb(255, 255, 204, 63),
                Color = OxyColor.FromArgb(255, 255, 204, 63)
            };

            series2.Points.Add(new DataPoint(0.0, 0.0));
            series2.Points.Add(new DataPoint(1.0, 0.0));
            series2.Points.Add(new DataPoint(2.0, 0.0));
            series2.Points.Add(new DataPoint(3.0, 2.0));
            series2.Points.Add(new DataPoint(4.0, 1.5));
            series2.Points.Add(new DataPoint(5.0, 0.5));
            series2.Points.Add(new DataPoint(6.0, 0.0));

            var series3 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 3,
                MarkerFill = OxyColor.FromArgb(255, 86, 182, 49),
                MarkerStroke = OxyColor.FromArgb(255, 86, 182, 49),
                Color = OxyColor.FromArgb(255, 86, 182, 49)
            };

            int aa = 1;
            series3.Points.Add(new DataPoint(aa, 0.0));
            series3.Points.Add(new DataPoint(1.0, 0.0));
            series3.Points.Add(new DataPoint(2.0, 0.0));
            series3.Points.Add(new DataPoint(3.0, 0.0));
            series3.Points.Add(new DataPoint(4.0, 0.0));
            series3.Points.Add(new DataPoint(5.0, 2.5));
            series3.Points.Add(new DataPoint(6.0, -1.5));

            plotModel.Series.Add(series1);
            plotModel.Series.Add(series2);
            plotModel.Series.Add(series3);

            return plotModel;
        }
    }
}
