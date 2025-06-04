using Csharp2_PlantingScheduler.Control.Managers;
using Csharp2_PlantingScheduler.Helpers;
using Csharp2_PlantingScheduler.Model;
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

namespace Csharp2_PlantingScheduler
{
    /// <summary>
    /// Interaction logic for GardenWindow.xaml
    /// </summary>
    public partial class GardenWindow : Window
    {
        private GardenManager gardenManager;
        private int editingIndex;
        private bool editingFlag = false;

        public GardenWindow(GardenManager currentGardenManager)
        {
            InitializeComponent();
            InitComboBoxes();
            gardenManager = currentGardenManager;
        }

        public GardenWindow(GardenManager currentGardenManager, int index)
        {
            InitializeComponent();
            InitComboBoxes();
            gardenManager = currentGardenManager;
            editingIndex = index;
            editingFlag = true;
            LoadGardenWhenEditing(editingIndex);
            windowName.Content = "Editing garden";
        }

        private void LoadGardenWhenEditing(int index)
        {
            Garden garden = gardenManager.GetAt(index);

            firstFrostFreeComboBox.SelectedItem = garden.FirstFrostFreeWeek;
            lastFrostFreeComboBox.SelectedItem = garden.LastFrostFreeWeek;
            nameTxtBox.Text = garden.GardenName;
            zoneComboBox.SelectedItem = garden.Zone;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DisplayQuestion("Are you sure? Unsaved changes will be lost", "Are you sure?"))
            {
                this.Close();
            }
        }

        private void InitComboBoxes()
        {
            for (int i = 1; i < 53; i++)
            {
                firstFrostFreeComboBox.Items.Add(i);
                lastFrostFreeComboBox.Items.Add(i);
            }

            firstFrostFreeComboBox.SelectedIndex = 0;
            lastFrostFreeComboBox.SelectedIndex = 0;

            zoneComboBox.ItemsSource = Enum.GetNames(typeof(Enums.GrowZone));
            zoneComboBox.SelectedIndex = 0;
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxtBox.Text;
            Enums.GrowZone zone = (Enums.GrowZone)Enum.Parse(typeof(Enums.GrowZone), zoneComboBox.SelectedItem.ToString()!);
            int frostFreeWeek = (int)firstFrostFreeComboBox.SelectedItem;
            int lastFrostWeek = (int)lastFrostFreeComboBox.SelectedItem;

            if (!string.IsNullOrEmpty(name))
            {
                Garden garden = new()
                {
                    GardenName = name,
                    Zone = zone,
                    FirstFrostFreeWeek = frostFreeWeek,
                    LastFrostFreeWeek = lastFrostWeek
                };

                if (editingFlag)
                {
                    gardenManager.ChangeAt(garden, editingIndex);
                }
                else
                {
                    gardenManager.Add(garden);
                }

                MessageBoxes.DisplayInfoBox($"Garden {garden.GardenName} added!", "Success");
                this.Close();
            }
            else
            {
                MessageBoxes.DisplayErrorBox("The garden needs a name");
            }
        }
    }
}
