using Csharp2_PlantingScheduler.Control.Managers;
using Csharp2_PlantingScheduler.Control.ScheduleCreators;
using Csharp2_PlantingScheduler.Helpers;
using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.ScheduleModel;
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
        //Constants
        private const int months = 12;
        private const int weeksPerMonth = 4;
        private const int weeksPerYear = months * weeksPerMonth;

        //Manager access
        private GardenManager gardenManager;
        private PlantManager plantManager;

        public MainWindow()
        {
            InitializeComponent();
            BuildScheduleSkeleton();
            gardenManager = new();
            plantManager = new();
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
                ScheduleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(25) });
            }

            //Month headers
            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;

            for (int i = 0; i < months; i++)
            {
                TextBlock monthHeader = new()
                {
                    Text = monthNames[i],
                    FontWeight = FontWeights.Bold,
                    HorizontalAlignment = HorizontalAlignment.Left
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

        private void generateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gardenManager.Count > 0 && plantManager.Count > 0)
            {
                if (gardenLstView.SelectedIndex != -1 && plantsLstView.SelectedIndex != -1)
                {
                    Garden garden = (Garden)gardenLstView.SelectedItem;
                    List<Plant> plants = plantsLstView.SelectedItems.Cast<Plant>().ToList();

                    List<ScheduleRow> scheduleRows = ScheduleRowParser.ParseToRows(garden, plants);

                    GenerateScheduleRows(scheduleRows);
                }
                else
                {
                    MessageBoxes.DisplayErrorBox("You need to select both a garden and one or more plants");
                }
            }
            else
            {
                MessageBoxes.DisplayErrorBox("You need to add both a garden and plants")
            }
        }

        private void GenerateScheduleRows(List<ScheduleRow> scheduleRows)
        {
            ScheduleGrid.RowDefinitions.Clear();
            ScheduleGrid.ColumnDefinitions.Clear();

            BuildScheduleSkeleton();

            foreach (ScheduleRow row in scheduleRows)
            {
                ScheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });

                int currentRow = ScheduleGrid.RowDefinitions.Count - 1;

                ScheduleGrid.Children.Add(CreateHeaderTextBlock(row.NameDisplay, currentRow, 0));
                ScheduleGrid.Children.Add(CreateHeaderTextBlock(row.TypeDisplay, currentRow, 1));
                ScheduleGrid.Children.Add(CreateHeaderTextBlock(row.WeeksToHarvestDisplay.ToString(), currentRow, 2));

                for (int week = 0; week < weeksPerYear; week++)
                {
                    Border weekCell = new Border
                    {
                        //If week is between startWeek and endWeek: add light green, else add transparent cells
                        Background = (week >= row.StartWeek && week <= row.EndWeek) ? Brushes.LightGreen : Brushes.Transparent,
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(0.5)
                    };

                    Grid.SetRow(weekCell, currentRow);

                    //Account for the three first cells
                    Grid.SetColumn(weekCell, 3 + week);
                    ScheduleGrid.Children.Add(weekCell);
                }
            }
        }

        private TextBlock CreateHeaderTextBlock(string text, int row, int col)
        {
            TextBlock txtBlock = new()
            {
                Text = text,
                Margin = new Thickness(2, 0, 2, 0),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Left
            };

            Grid.SetRow(txtBlock, row);
            Grid.SetColumn(txtBlock, col);

            return txtBlock;
        }
    }
}