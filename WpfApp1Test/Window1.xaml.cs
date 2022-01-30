using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace WpfApp1Test
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window

    {
        int[] data = new int[3];

        public void setData(int[] data) {
            this.data = data;
        }

        public Window1()
        {
            InitializeComponent();

        }

        public void loadChart()
        {
            Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            chart.Series = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Municipio",
                Values = new ChartValues<double> {data[0]},
                PushOut = 15,
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Isla",
                Values = new ChartValues<double> {data[1]},
                DataLabels = true,
                LabelPoint = labelPoint
            },
            new PieSeries
            {
                Title = "Área no municipalizada",
                Values = new ChartValues<double> {data[2]},
                DataLabels = true,
                LabelPoint = labelPoint
            },

        };
        }
    }

    
}
