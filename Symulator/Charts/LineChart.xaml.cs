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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using System.Data;
using LiveCharts.Definitions.Series;

namespace Charts
{
    public partial class LineChart : Window
    {
        #region Properties

        public SeriesCollection SeriesCollection { get; set; }

        public Dictionary<MenuItem, ISeriesView> SeriesDictionary { get; set; }

        #endregion

        #region ctor

        public LineChart(DataSet ds)
        {
            InitializeComponent();
            SetUpSeries(ds);
            chart.Series = SeriesCollection;
            chart.ContextMenu = CreateContextMenu();
            this.Show();
        }

        public LineChart(List<double> list) : this(ToDataSet(list))
        {}

        private static DataSet ToDataSet(List<double> list)
        {
            var ds = new DataSet();
            var dt = new DataTable("Wynik");
            ds.Tables.Add(dt);
            dt.Columns.Add("Czasy", typeof(double));
            foreach (var value in list)
            {
                var newRow = dt.NewRow();
                newRow["Czasy"] = value;
                dt.Rows.Add(newRow);
            }
            return ds;
        }

        private void SetUpSeries(DataSet ds)
        {
            SeriesCollection = new SeriesCollection();
            foreach (DataTable dt in ds.Tables)
            {
                var firstColName = dt.Columns[0].ColumnName;
                List<double> values = new List<double>();
                foreach (DataRow row in dt.Rows)
                {
                    values.Add((double)row[firstColName]);
                }

                var lineSeries = new LineSeries()
                {
                    Title = dt.TableName,
                    Values = new ChartValues<double>(values)
                };
                SeriesCollection.Add(lineSeries);
            }

        }

        private ContextMenu CreateContextMenu()
        {
            var contextMenu = new ContextMenu();
            SeriesDictionary = new Dictionary<MenuItem, ISeriesView>();

            foreach (var serie in SeriesCollection)
            {
                var item = new MenuItem();
                item.Header = string.Format("Ukryj {0}", serie.Title);

                item.Click += OnMenuItemClick;

                contextMenu.Items.Add(item);
                SeriesDictionary.Add(item, serie);
            }

            return contextMenu;
        }

        private void OnMenuItemClick(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var serie = SeriesDictionary[item];

            if (serie.IsSeriesVisible)
            {
                item.Header = string.Format("Pokaż {0}", serie.Title);
                (serie as LineSeries).Visibility = Visibility.Collapsed;
            }
            else
            {
                item.Header = string.Format("Ukryj {0}", serie.Title);
                (serie as LineSeries).Visibility = Visibility.Visible;
            }
        }

        #endregion
    }
}
