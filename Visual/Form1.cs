using System;
using System.ComponentModel;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using Polynominterpolation;

namespace Visual
{
    public partial class Form1 : Form
    {
        PlotModel plotModel;
        bool onMouseHold = false;
        int indexOfCurrentSelectedPoint = -1;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Visualisation Polynomial Functions";
            dataGridView1.RowCount++;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "x";
            dataGridView1.Columns[1].HeaderText = "f(x)";

            plotModel = new PlotModel();
            plotModel.Series.Add(new LineSeries());
            plotModel.Series.Add(new LineSeries());
            plotModel.Series.Add(new LineSeries());

            //Adding y - Coordinate Axes
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                ExtraGridlines = new double[] { 0 },
                ExtraGridlineThickness = 1,
                ExtraGridlineColor = OxyColors.Black,
                MajorGridlineThickness = 1,
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = OxyPlot.LineStyle.Solid
            }
            );

            //Adding x - Coordinate Axes
            plotModel.Axes.Add(new OxyPlot.Axes.LinearAxis
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                ExtraGridlines = new double[] { 0 },
                ExtraGridlineThickness = 1,
                ExtraGridlineColor = OxyColors.Black,
                MajorGridlineThickness = 1,
                MinorGridlineStyle = LineStyle.Solid,
                MajorGridlineStyle = OxyPlot.LineStyle.Solid
            }
            );

            plotView1.MouseUp += PlotView_MouseUp;

            InitalizeMouseEvents(plotModel);

            plotView1.Model = plotModel;
            plotModel.InvalidatePlot(true);
        }

        private void PlotView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && onMouseHold)
            {
                onMouseHold = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawAll();
        }

        private void InitalizeMouseEvents(PlotModel myModel)
        {
            PointD[] points = GetPointsFromGridPointD(dataGridView1);
            LineSeries controlPoints = new LineSeries();
            controlPoints.MarkerType = MarkerType.Circle;
            controlPoints.Color = OxyColors.Red;
            controlPoints.LineStyle = LineStyle.None;

            myModel.MouseDown += (s, e) =>
            {
                double x, y;

                PointD[] pointsLocal = GetPointsFromGridPointD(dataGridView1);

                x = controlPoints.InverseTransform(e.Position).X;
                y = controlPoints.InverseTransform(e.Position).Y;

                //Get the the distance from two points 9 pixels apart
                ScreenPoint screenPointOne = new ScreenPoint(0, 0);
                ScreenPoint screenPointTwo = new ScreenPoint(5, 5);

                DataPoint dataPointOne = controlPoints.InverseTransform(screenPointOne);
                DataPoint dataPointTwo = controlPoints.InverseTransform(screenPointTwo);

                double dx = dataPointOne.X - dataPointTwo.X;
                double dy = dataPointOne.Y - dataPointTwo.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);

                int index;

                bool sucessfullGrap = IsInDistance(distance, pointsLocal, new PointD(x, y), out index);

                //deletes Point
                if (e.ChangedButton == OxyMouseButton.Right && sucessfullGrap)
                {
                    dataGridView1.Rows.RemoveAt(index);
                    pointsLocal = GetPointsFromGridPointD(dataGridView1);
                    DrawFunction(myModel, pointsLocal);
                    DrawControlPoints(myModel, controlPoints, pointsLocal);
                    //Updates the View
                    myModel.InvalidatePlot(true);

                    return;
                }

                //adds new Point
                if (e.ChangedButton == OxyMouseButton.Left && !sucessfullGrap)
                {
                    AppendPointToDataGridView(dataGridView1, new PointD(x, y));
                    pointsLocal = GetPointsFromGridPointD(dataGridView1);
                    DrawFunction(myModel, pointsLocal);
                    DrawControlPoints(myModel, controlPoints, pointsLocal);
                    //Updates the View
                    myModel.InvalidatePlot(true);

                    return;
                }

                if (e.ChangedButton == OxyMouseButton.Left && sucessfullGrap)
                {
                    onMouseHold = true;
                    indexOfCurrentSelectedPoint = index;
                }

            };

            myModel.MouseMove += (s, e) =>
            {
                if (onMouseHold)
                {
                    PointD[] pointsLocal = GetPointsFromGridPointD(dataGridView1);

                    double x, y;

                    x = controlPoints.InverseTransform(e.Position).X;
                    y = controlPoints.InverseTransform(e.Position).Y;

                    dataGridView1.Rows[indexOfCurrentSelectedPoint].Cells[0].Value = x.ToString();
                    dataGridView1.Rows[indexOfCurrentSelectedPoint].Cells[1].Value = y.ToString();

                    DrawFunction(myModel, pointsLocal);
                    DrawControlPoints(myModel, controlPoints, pointsLocal);
                    myModel.InvalidatePlot(true);
                }
            };


            DrawControlPoints(myModel, controlPoints, points);
        }

        private void DrawAll()
        {
            PointD[] points = GetPointsFromGridPointD(dataGridView1);
            LineSeries controlPoints = new LineSeries();
            controlPoints.MarkerType = MarkerType.Circle;
            controlPoints.Color = OxyColors.Red;
            controlPoints.LineStyle = LineStyle.None;

            DrawFunction(plotModel, points);
            DrawControlPoints(plotModel, controlPoints, points);

            plotModel.InvalidatePlot(true);
        }

        private double HMethod(Function function, double x, double h = 0.0000001)
        {
            return (function(x + h) - function(x)) / h;
        }

        private void DrawFunction(PlotModel myModel, PointD[] points)
        {
            LineSeries splineLine = new LineSeries();
            splineLine.MarkerType = MarkerType.None;
            splineLine.Color = OxyColors.Blue;

            LineSeries derivative = new LineSeries();
            derivative.MarkerType = MarkerType.None;
            derivative.Color = OxyColors.Orange;

            if (points.Length == 0)
            {
                myModel.Series[0] = splineLine;
                myModel.Series[2] = derivative;
                return;
            }

            Term term = new Term(ConvertPointDToDoubleArray(points), points.Length - 1);

            double xmin = Convert.ToDouble(textBoxXMin.Text);
            double xmax = Convert.ToDouble(textBoxXMax.Text);
            double stepSize = 0.1;

            for (double x = xmin; x < xmax; x += stepSize)
            {
                splineLine.Points.Add(new DataPoint(x, term.calc(x)));

                if (checkBoxDerivative.Checked)
                    derivative.Points.Add(new DataPoint(x, HMethod(term.calc, x)));
            }

            myModel.Series[0] = splineLine;
            myModel.Series[2] = derivative;
        }

        private void DrawControlPoints(PlotModel myModel, LineSeries controlPoints, PointD[] points)
        {
            controlPoints.Points.Clear();

            for (int i = 0; i < points.Length; i++)
            {
                controlPoints.Points.Add(new DataPoint(points[i].X, points[i].Y));
            }

            myModel.Series[1] = controlPoints;
        }

        public bool IsInDistance(double maxDistance, PointD[] points, PointD point, out int indexOfMin)
        {
            int currentIndex = 0;
            double currentMaxDistance = maxDistance;

            for (int i = 0; i < points.Length; i++)
            {
                double dx = points[i].X - point.X;
                double dy = points[i].Y - point.Y;

                double distance = Math.Sqrt(dx * dx + dy * dy);
                if (currentMaxDistance > distance)
                {
                    currentIndex = i;
                    currentMaxDistance = distance;
                }
            }

            if (maxDistance == currentMaxDistance)
            {
                indexOfMin = 0;
                return false;
            }


            indexOfMin = currentIndex;
            return true;
        }

        private PointD[] GetPointsFromGridPointD(DataGridView dataGridView)
        {
            PointD[] table = new PointD[dataGridView.RowCount - 1];

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                double x = dataGridView[0, i].Value != null ? Convert.ToDouble(dataGridView[0, i].Value.ToString()) : 0d;
                double y = dataGridView[1, i].Value != null ? Convert.ToDouble(dataGridView[1, i].Value.ToString()) : 0d;

                table[i] = new PointD(x, y);
            }

            return table;
        }

        private double[,] GetPointsFromGrid(DataGridView dataGridView)
        {
            double[,] table = new double[dataGridView.ColumnCount, dataGridView.RowCount - 1];

            for (int i = 0; i < dataGridView.RowCount - 1; i++)
            {
                float x = Convert.ToSingle(dataGridView[0, i].Value.ToString());
                float y = Convert.ToSingle(dataGridView[1, i].Value.ToString());

                table[0, i] = x;
                table[1, i] = y;
            }

            return table;
        }

        private void AppendPointToDataGridView(DataGridView dataGridView, PointD point)
        {
            dataGridView.RowCount++;
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[0].Value = point.X.ToString();
            dataGridView.Rows[dataGridView.RowCount - 2].Cells[1].Value = point.Y.ToString();
        }

        private double[,] ConvertPointDToDoubleArray(PointD[] points)
        {
            double[,] table = new double[2, points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                table[0, i] = points[i].X;
                table[1, i] = points[i].Y;
            }

            return table;
        }

        private void textBoxXMin_TextChanged(object sender, EventArgs e)
        {
            if (!CheckTextBoxForDouble(((TextBox)sender)))
                return;

            DrawAll();
        }

        private void textBoxXMax_TextChanged(object sender, EventArgs e)
        {
            if (!CheckTextBoxForDouble(((TextBox)sender)))
                return;

            DrawAll();
        }
        private bool CheckTextBoxForDouble(TextBox textBox)
        {
            double number;
            return double.TryParse(textBox.Text, out number);
        }

        private void textBoxXMin_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckTextBoxForDouble(((TextBox)sender)))
                e.Cancel = true;
        }

        private void textBoxXMax_Validating(object sender, CancelEventArgs e)
        {
            if (!CheckTextBoxForDouble(((TextBox)sender)))
                e.Cancel = true;
        }

        //Validating of DataGridView Cells
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            double number;

            if (e.RowIndex != dataGridView1.RowCount - 1 && !double.TryParse(e.FormattedValue.ToString(), out number))
            {
                if (e.FormattedValue.ToString() == "")
                    return;

                e.Cancel = true;
            }
        }

        private void checkBoxDerivative_CheckedChanged(object sender, EventArgs e)
        {
            DrawAll();
        }
    }
}