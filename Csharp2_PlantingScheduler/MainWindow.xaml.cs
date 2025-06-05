using Csharp2_PlantingScheduler.Control.Managers;
using Csharp2_PlantingScheduler.Control.ScheduleCreators;
using Csharp2_PlantingScheduler.Helpers;
using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.ScheduleModel;
using Microsoft.Win32;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        //Properties
        public GardenManager GardenManager => gardenManager;
        public PlantManager PlantManager => plantManager;
        private string FilePath { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            BuildScheduleSkeleton();
            gardenManager = new();
            plantManager = new();
            FilePath = string.Empty;
            DataContext = this;
        }

        private void BuildScheduleSkeleton()
        {
            scheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
            scheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });

            //Type/name/weeks to harvest columns
            for (int i = 0; i < 3; i++)
            {
                scheduleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }

            //Week columns
            for (int i = 0; i < weeksPerYear; i++)
            {
                scheduleGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(25) });
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

                scheduleGrid.Children.Add(monthHeader);
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
                scheduleGrid.Children.Add(weekHeader);
            }
        }

        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (gardenManager.Collection.Count > 0 && plantManager.Collection.Count > 0)
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
                MessageBoxes.DisplayErrorBox("You need to add both a garden and plants");
            }
        }

        private void GenerateScheduleRows(List<ScheduleRow> scheduleRows)
        {
            scheduleGrid.RowDefinitions.Clear();
            scheduleGrid.ColumnDefinitions.Clear();

            BuildScheduleSkeleton();

            foreach (ScheduleRow row in scheduleRows)
            {
                scheduleGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });

                int currentRow = scheduleGrid.RowDefinitions.Count - 1;

                scheduleGrid.Children.Add(CreateHeaderTextBlock(row.NameDisplay, currentRow, 0));
                scheduleGrid.Children.Add(CreateHeaderTextBlock(row.TypeDisplay, currentRow, 1));
                scheduleGrid.Children.Add(CreateHeaderTextBlock(row.WeeksToHarvestDisplay.ToString(), currentRow, 2));

                for (int week = 0; week < weeksPerYear; week++)
                {
                    Brush cellColor = Brushes.Transparent;

                    int indoorEndWeek = row.StartWeek + row.IndoorWeeks;
                    int coldStartEndWeek = row.StartWeek + row.ColdStartWeeks;

                    //If indoor period
                    if (row.IndoorWeeks > 0 && week >= row.StartWeek && week < indoorEndWeek)
                    {
                        cellColor = Brushes.LightBlue;
                    }
                    //If cold start period
                    else if (row.ColdStartWeeks > 0 && week >= row.StartWeek && week < coldStartEndWeek)
                    {
                        cellColor = Brushes.LightSkyBlue;
                    }
                    //If transplanted outdoor
                    else if (week >= row.StartWeek && week <= row.EndWeek)
                    {
                        cellColor = Brushes.LightGreen;
                    }

                    Border weekCell = new()
                    {
                        Background = cellColor,
                        BorderBrush = Brushes.Gray,
                        BorderThickness = new Thickness(0.5)
                    };

                    Grid.SetRow(weekCell, currentRow);

                    //Account for the three first cells
                    Grid.SetColumn(weekCell, 3 + week);
                    scheduleGrid.Children.Add(weekCell);
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

        private void AddGardenBtn_Click(object sender, RoutedEventArgs e)
        {
            GardenWindow gardenWindow = new(gardenManager);

            gardenWindow.ShowDialog();
        }

        private void AddPlantBtn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(plantManager);

            plantWindow.ShowDialog();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            bool plantSelected = plantsLstView.SelectedItems.Count == 1;
            bool gardenSelected = gardenLstView.SelectedItems.Count == 1;

            if (plantSelected && !gardenSelected)
            {
                int index = plantsLstView.SelectedIndex;

                PlantWindow editingPlantWindow = new(plantManager, index);

                editingPlantWindow.ShowDialog();
            }
            else if (!plantSelected && gardenSelected)
            {
                int index = gardenLstView.SelectedIndex;

                GardenWindow editGardenWindow = new(gardenManager, index);

                editGardenWindow.ShowDialog();
            }
            else
            {
                MessageBoxes.DisplayErrorBox("You need to pick one garden or plant to edit");
            }
        }

        private void ExitBtn_Click(Object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DisplayQuestion("Are you sure? Unsaved changes will be lost", "Exit?"))
            {
                this.Close();
            }
        }

        private void NewBtn_Click(Object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DisplayQuestion("Are you sure? Unsaved changes will be lost", "New?"))
            {
                plantManager.DeleteAll();
                gardenManager.DeleteAll();

                FilePath = string.Empty;
            }
        }

        private void OpenJson_Click(Object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            if (open.ShowDialog() == true)
            {
                FilePath = open.FileName;

                try
                {
                    FileManager file = new(plantManager, gardenManager);
                    file.Deserialize(FilePath);
                }
                catch (Exception ex)
                {
                    MessageBoxes.DisplayErrorBox($"Something went wrong \n {ex.Message}");
                }
            }
        }

        private void SaveJson_Click(Object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            if (save.ShowDialog() == true)
            {
                FilePath = save.FileName;

                try
                {
                    FileManager file = new(plantManager, gardenManager);
                    file.Serialize(FilePath);
                }
                catch (Exception ex)
                {
                    MessageBoxes.DisplayErrorBox($"Something went wrong \n {ex.Message}");
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            bool plantSelected = plantsLstView.SelectedItems.Count == 1;
            bool gardenSelected = gardenLstView.SelectedItems.Count == 1;

            if (plantSelected && !gardenSelected)
            {
                if (MessageBoxes.DisplayQuestion("Are you sure?", "Delete?"))
                {
                    int plantIndex = plantsLstView.SelectedIndex;
                    plantManager.DeleteAt(plantIndex);
                }
            }
            else if (!plantSelected && gardenSelected)
            {
                if (MessageBoxes.DisplayQuestion("Are you sure?", "Delete?"))
                {
                    int gardenIndex = gardenLstView.SelectedIndex;
                    gardenManager.DeleteAt(gardenIndex);
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    FileManager file = new(plantManager, gardenManager);
                    file.Serialize(FilePath);
                }
                catch (Exception ex)
                {
                    MessageBoxes.DisplayErrorBox($"Something went wrong \n {ex.Message}");
                }
            }
            else
            {
                SaveJson_Click(sender, e);
            }
        }
    }
}