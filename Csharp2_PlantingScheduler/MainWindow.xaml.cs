using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Csharp2_PlantingScheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int months = 12;
        private const int weeksPerMonth = 4;
        private const int weeksPerYear = months * weeksPerMonth;

        public MainWindow()
        {
            InitializeComponent();
            BuildScheduleSkeleton();
        }

        private void BuildScheduleSkeleton()
        {
            ScheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            ScheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });

            //Type/name/weeks to harvest columns
            for (int i = 0; i < 3; i++)
            {
                ScheduleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            //Week columns
            for (int i = 0; i < weeksPerYear; i++)
            {
                ScheduleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            }

            //Month headers
            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

            for (int i = 0; i < months; i++)
            {
                TextBlock monthHeader = new()
                {
                    Text = monthNames[i],
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                Grid.SetRow(monthHeader, 0);
                Grid.SetColumn(monthHeader, 3 + i * 4);

                Grid.SetColumnSpan(monthHeader, 4);

                ScheduleGrid.Children.Add(monthHeader);
            }

            for (int i = 0; i < weeksPerYear; i++)
            {
                TextBlock weekHeader = new()
                {
                    Text = $"W{i + 1}",
                    FontSize = 10,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                Grid.SetRow(weekHeader, 1);
                Grid.SetColumn(weekHeader, 3 + i);
                ScheduleGrid.Children.Add(weekHeader);
            }
        }
    }
}