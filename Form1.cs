using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;


namespace ads
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        int Partition(double[] array, int start, int end)
        {
            int marker = start; // divides left and right subarrays
            for (int i = start; i < end; i++)
            {
                if (array[i] < array[end]) // array[end] is pivot
                {
                    (array[marker], array[i]) = (array[i], array[marker]);
                    marker += 1;
                }
            }
            // put pivot(array[end]) between left and right subarrays
            (array[marker], array[end]) = (array[end], array[marker]);
            return marker;
        }

        void Quicksort(double[] array, int start, int end)
        {
            if (start >= end)
                return;

            int pivot = Partition(array, start, end);
            Quicksort(array, start, pivot - 1);
            Quicksort(array, pivot + 1, end);
        }

        private void CreateFunc(double lambda, int count)
        {
            chart1.Series.Add("Выборочная функция распределения");
            chart1.Series["Выборочная функция распределения"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Выборочная функция распределения"].Color = Color.FromArgb(255, 255, 0, 0);

            double[] res = new double[count];
            double[] resSort = new double[count];

            double y = 0.0;

            double x_ = 0.0;
            double S_2 = 0.0;
            double me_ = 0.0;
            double R = 0.0;
            double D = 0.0;

            string str="";

            Random rnd = new Random();
            double x = System.Convert.ToDouble(rnd.NextDouble());

            for (int n = 0; n < count; n++)
            {
                x = System.Convert.ToDouble(rnd.NextDouble());
                if (x < 0.5)
                {
                    y = (Math.Log(2 * x)) / (lambda);
                }
                else if (x > 0.5)
                {
                    y = -((Math.Log(2 - (2 * x))) / (lambda));
                }
                else if (x == 0.5)
                {
                    y = 0;
                }
                res[n] = y;
                resSort[n] = y;
                x_ += y;
            }

            for (int n = 0; n < count; n++)
            {
                S_2 += (res[n] - (x_ / count)) * (res[n] - (x_ / count));
            }

            S_2 = S_2 / count;

            Quicksort(resSort, 0, count - 1);

            if (count % 2 == 0)
            {
                me_ = (resSort[(count - 1) / 2] + resSort[((count - 1) / 2) + 1]) / 2;
            }
            else
            {
                me_ = (resSort[(((count - 1) / 2))]);
            }

            for (int n = 0; n < count; ++n)
            {
                str = str + System.Convert.ToString(resSort[n]) + "\n";
            }

            double d1, d2, dmax = 0.0;
            double T = 0;
            this.chart1.Series["Выборочная функция распределения"].Points.AddXY(resSort[0], 1/System.Convert.ToDouble(count));
            for (int n = 1; n < count; ++n)
            {
                this.chart1.Series["Выборочная функция распределения"].Points.AddXY(resSort[n], n / System.Convert.ToDouble(count));
                this.chart1.Series["Выборочная функция распределения"].Points.AddXY(resSort[n], (n + 1) / System.Convert.ToDouble(count));

                if(resSort[n] <= 0)
                {
                    T = (0.5) * Math.Exp(lambda * resSort[n]);
                }
                else
                {
                    T = 1 - ((0.5) * Math.Exp((-1) * lambda * resSort[n]));
                }
                d1 = Math.Abs((n / System.Convert.ToDouble(count)) - T);
                d2 = Math.Abs(((n + 1) / System.Convert.ToDouble(count)) - T);
                dmax = Math.Max(d1, d2);

                if (dmax >= D)
                {
                    D = dmax;
                }

            }

            MessageBox.Show(str);

            MessageBox.Show("Матожидание = 0\n" + "Выборочное среднее = " + System.Convert.ToString(x_ / count) + "\n" + "Отклонение от матожидания = " + System.Convert.ToString((-1) * (x_ / count)) +
            "\n" + "Дисперсия = " + System.Convert.ToString(2 / ((lambda) * (lambda))) + "\n" + "Выборочная дисперсия = " + System.Convert.ToString(S_2) + "\n" + "Отклонение от дисперсии = " + System.Convert.ToString(Math.Abs((2 / ((lambda) * (lambda))) - S_2))
            + "\n" + "Медиана = " + System.Convert.ToString(me_) + "\n" + "Размах = " + System.Convert.ToString(resSort[count - 1] - resSort[0]) + "\n" + "Мера расхождения = " + System.Convert.ToString(D));


        }

        private void CreateGraph(double lambda)
        {
            double h = 0.1;
            int right = 100;

            chart1.Series.Clear();
            chart1.Series.Add("Функция распределения");
            chart1.Series["Функция распределения"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Функция распределения"].Color = Color.FromArgb(255, 0, 0, 255);

            for (int count = -right; count < right; ++count)
            {
                double t = count *h;
                if (t<=0)
                {
                    this.chart1.Series["Функция распределения"].Points.AddXY(t, (0.5) * Math.Exp(lambda * t));
                }
                else
                {
                    this.chart1.Series["Функция распределения"].Points.AddXY(t, 1-((0.5) * Math.Exp((-1)*lambda * t)));
                }



            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double lambda = System.Convert.ToDouble(this.textBox1.Text);
            int count = System.Convert.ToInt32(this.textBox2.Text);
            CreateGraph(lambda);
            CreateFunc(lambda, count);
            chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum -= 2;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum += 2;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum -= 2;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Maximum += 2;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum -= 2;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum += 2;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum -= 2;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum += 2;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
        }
    }
}
