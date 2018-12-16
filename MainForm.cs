
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace PolylineSmooth
{
    public partial class MainForm
    {
        public MainForm()
        {
            this.InitializeComponent();

            initForm();

            butSmooth.Click += (sender,args) => clback("smooth");
            comboMethod.SelectedIndexChanged += (sender,args) => clback("methodchange");
            numIterations.ValueChanged += (sender,args) => clback("numiter");
            numTension.ValueChanged += (sender,args) => clback("numtension");
        }

        private void initForm()
        {

            // set up chart
            chart1.Legends[0].Enabled = true;
            chart1.Legends[0].IsDockedInsideChartArea = true;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].BorderColor = Color.Black;
            chart1.Legends[0].IsTextAutoFit = false;
            chart1.Legends[0].IsEquallySpacedItems = true;
            chart1.Legends[0].MaximumAutoSize = 100;
            chart1.Series.Clear();

            {
                var withBlock = chart1.ChartAreas[0];
                withBlock.AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                withBlock.AxisX.MajorGrid.Enabled = false;

                withBlock.AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
                withBlock.AxisY.MajorGrid.Enabled = false;
            }

            // set up combo
            comboMethod.SelectedIndex = 0;
            clback("methodchange");

            // set up and draw a polyline
            List<PointD> data = getData();
            plotData(data);
        }

        private void clback(string action)
        {
            if (action == "smooth")
            {
                List<PointD> data = getData();
                List<PointD> smooth;
                string stitle = "";

                if (comboMethod.SelectedIndex == 0)
                {
                    smooth = getSplineInterpolationCatmullRom(data, System.Convert.ToInt32(numIterations.Value));
                    stitle = string.Format("Catmull-Rom Interpolation i={0} pointcount={1}", numIterations.Value, smooth.Count);
                }
                else
                {
                    smooth = getCurveSmoothingChaikin(data, System.Convert.ToDouble(numTension.Value), System.Convert.ToInt32(numIterations.Value));
                    stitle = string.Format("Chaikin Approximation i={0} t={1} pointcount={2}", numIterations.Value, numTension.Value, smooth.Count);
                }
                plotData(data);
                plotLine(smooth, Color.Black, 2, ChartDashStyle.Solid, stitle);
            }
            else if (action == "methodchange"
            )
            {
                if (comboMethod.SelectedIndex == 0)
                {
                    // catmull-rom
                    numTension.Enabled = false;
                    labTension.Enabled = false;
                    labIter.Text = "Nr of interpolated points";
                    numIterations.Maximum = 20;
                }
                else
                {
                    numTension.Enabled = true;
                    labTension.Enabled = true;
                    labIter.Text = "Nr of iterations";
                    numIterations.Maximum = 10;
                }
                clback("smooth");
            }
            else if (action == "numiter"
            )
                clback("smooth");
            else if (action == "numtension"
             )
                clback("smooth");
        }



        private List<PointD> getCurveSmoothingChaikin(List<PointD> points, double tension, int nrOfIterations)
        {
            // checks
            if (points == null || points.Count < 3)
                return null;

            if (nrOfIterations < 1)
                nrOfIterations = 1;
            else if (nrOfIterations > 10)
                nrOfIterations = 10;

            if (tension < 0)
                tension = 0;
            else if (tension > 1
             )
                tension = 1;

            // the tension factor defines a scale between corner cutting distance in segment half length, i.e. between 0.05 and 0.45
            // the opposite corner will be cut by the inverse (i.e. 1-cutting distance) to keep symmetry
            // with a tension value of 0.5 this amounts to 0.25 = 1/4 and 0.75 = 3/4 the original Chaikin values
            double cutdist = 0.05 + (tension * 0.4);

            // make a copy of the pointlist and feed it to the iteration
            List<PointD> nl = new List<PointD>();
            var loopTo = points.Count - 1;
            for (int i = 0; i <= loopTo; i++)
                nl.Add(new PointD(points[i]));
            var loopTo1 = nrOfIterations;
            for (int i = 1; i <= loopTo1; i++)
                nl = getSmootherChaikin(nl, cutdist);

            return nl;
        }

        private List<PointD> getSmootherChaikin(List<PointD> points, double cuttingDist)
        {
            List<PointD> nl = new List<PointD>();

            // always add the first point
            nl.Add(new PointD(points[0]));

            PointD q, r;
            var loopTo = points.Count - 2;
            for (int i = 0; i <= loopTo; i++)
            {
                q = (1 - cuttingDist) * points[i] + cuttingDist * points[i + 1];
                r = cuttingDist * points[i] + (1 - cuttingDist) * points[i + 1];
                nl.Add(q);
                nl.Add(r);
            }

            // always add the last point
            nl.Add(new PointD(points[points.Count - 1]));

            return nl;
        }



        private List<PointD> getSplineInterpolationCatmullRom(List<PointD> points, int nrOfInterpolatedPoints)
        {
            try
            {
                // The Catmull-Rom Spline, requires at least 4 points so it is possible to extrapolate from 3 points, but not from 2.
                // you would get a straight line anyway
                if (points.Count < 3)
                    throw new Exception("Catmull-Rom Spline requires at least 3 points");

                // could throw an error on the following, but it is easily fixed implicitly
                if (nrOfInterpolatedPoints < 1)
                    nrOfInterpolatedPoints = 1;

                // create a new pointlist to do splining on
                // if you don't do this, the original pointlist gets extended with the exptrapolated points
                List<PointD> spoints = new List<PointD>();
                foreach (PointD p in points)
                    spoints.Add(new PointD(p));

                // always extrapolate the first and last point out
                double dx = spoints[1].X - spoints[0].X;
                double dy = spoints[1].Y - spoints[0].Y;
                spoints.Insert(0, new PointD(spoints[0].X - dx, spoints[0].Y - dy));
                dx = spoints[spoints.Count - 1].X - spoints[spoints.Count - 2].X;
                dy = spoints[spoints.Count - 1].Y - spoints[spoints.Count - 2].Y;
                spoints.Insert(spoints.Count, new PointD(spoints[spoints.Count - 1].X + dx, spoints[spoints.Count - 1].Y + dy));

                // Note the nrOfInterpolatedPoints acts as a kind of tension factor between 0 and 1 because it is normalised
                // to 1/nrOfInterpolatedPoints. It can never be 0
                double t = 0;
                PointD spoint;
                List<PointD> spline = new List<PointD>();
                var loopTo = spoints.Count - 4;
                for (int i = 0; i <= loopTo; i++)
                {
                    spoint = new PointD();
                    var loopTo1 = nrOfInterpolatedPoints - 1;
                    for (int intp = 0; intp <= loopTo1; intp++)
                    {
                        t = 1 / (double)nrOfInterpolatedPoints * intp;

                        spoint = 0.5 * (2 * spoints[i + 1] + (-1 * spoints[i] + spoints[i + 2]) * t + (2 * spoints[i] - 5 * spoints[i + 1] + 4 * spoints[i + 2] - spoints[i + 3]) * Math.Pow(t, 2) + (-1 * spoints[i] + 3 * spoints[i + 1] - 3 * spoints[i + 2] + spoints[i + 3]) * Math.Pow(t, 3));


                        spline.Add(new PointD(spoint));
                    }
                }

                // add the last point, but skip the interpolated last point, so second last...
                spline.Add(spoints[spoints.Count - 2]);
                return spline;
            }
            catch (Exception exc)
            {
                // Debug.Print(exc.ToString)
                return null;
            }
        }



        private void plotData(List<PointD> data)
        {
            setExtents(0, 0, 10, 10, true);
            plotLine(data, Color.Red, 1, ChartDashStyle.Dash, "Data");
            plotPoints(data, Color.Black, 8, false);
        }

        private List<PointD> getData()
        {
            List<PointD> ff = new List<PointD>();
            ff.Add(new PointD(3, 0.5));
            ff.Add(new PointD(2, 1));
            ff.Add(new PointD(3, 2));
            ff.Add(new PointD(3, 3));
            ff.Add(new PointD(4, 2.5));
            ff.Add(new PointD(4.8, 3.7));
            ff.Add(new PointD(3, 5.5));
            ff.Add(new PointD(6, 8));
            ff.Add(new PointD(7, 9.5));
            ff.Add(new PointD(8.3, 5.1));
            ff.Add(new PointD(6.5, 4.2));
            ff.Add(new PointD(7, 3));
            ff.Add(new PointD(8, 2));
            ff.Add(new PointD(9, 2));
            ff.Add(new PointD(9, 3));
            ff.Add(new PointD(3, 0.5));
            return ff;
        }

        private void setExtents(double xmin, double ymin, double xmax, double ymax, bool clear)
        {
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax;
            chart1.ChartAreas[0].AxisY.Minimum = ymin;
            chart1.ChartAreas[0].AxisY.Maximum = ymax;
            if (clear)
                chart1.Series.Clear();
        }

        private void plotPoints(List<PointD> points, Color col, int size, bool filled)
        {
            if (points == null || points.Count < 1)
                return;

            List<double> xg = new List<double>(), yg = new List<double>();

            foreach (PointD pt in points)
            {
                xg.Add(pt.X);
                yg.Add(pt.Y);
            }

            Series sp = chart1.Series.Add("points" + chart1.Series.Count + 1);
            sp.ChartType = SeriesChartType.Point;
            sp.Points.DataBindXY(xg, yg);
            sp.MarkerSize = size;
            sp.MarkerStyle = MarkerStyle.Circle;
            sp.IsVisibleInLegend = false;
            if (filled)
                sp.Color = col;
            else
            {
                sp.MarkerBorderColor = col;
                sp.MarkerColor = Color.Transparent;
            }
        }

        private void plotLine(List<PointD> points, Color col, int width, ChartDashStyle dash)
        {
            plotLine(points, col, width, dash, "");
        }

        private void plotLine(List<PointD> points, Color col, int width, ChartDashStyle dash, string title)
        {
            if (points == null || points.Count < 1)
                return;

            List<double> xg = new List<double>(), yg = new List<double>();

            foreach (PointD pt in points)
            {
                xg.Add(pt.X);
                yg.Add(pt.Y);
            }

            string sname = "line" + chart1.Series.Count + 1;
            if (title != "")
                sname = title;

            Series sp = chart1.Series.Add(sname);
            sp.ChartType = SeriesChartType.Line;
            sp.Points.DataBindXY(xg, yg);
            sp.Color = col;
            sp.BorderWidth = width;
            sp.BorderDashStyle = dash;
        }
    }
}
