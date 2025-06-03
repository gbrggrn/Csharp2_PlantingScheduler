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
        public GardenWindow()
        {
            InitializeComponent();
            InitComboBoxes();
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
            for (int i = 1; i < 52; i++)
            {
                firstFrostFreeComboBox.Items.Add(i);
                lastFrostFreeComboBox.Items.Add(i);
            }

            firstFrostFreeComboBox.SelectedIndex = 0;
            lastFrostFreeComboBox.SelectedIndex = 0;

            zoneComboBox.ItemsSource = Enum.GetName(typeof(Enums.GrowZone), Name);
            zoneComboBox.SelectedIndex = 0;
        }
    }
}
