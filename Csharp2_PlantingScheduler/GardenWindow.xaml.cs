﻿using Csharp2_PlantingScheduler.Control.Managers;
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
        private readonly GardenManager gardenManager;
        private readonly int editingIndex;
        private readonly bool editingFlag = false;

        public GardenWindow(GardenManager currentGardenManager)
        {
            InitializeComponent();
            InitComboBoxes();
            gardenManager = currentGardenManager;
        }

        /// <summary>
        /// Second constructor if window is open for editing
        /// </summary>
        /// <param name="currentGardenManager">Current instance of gardenManager</param>
        /// <param name="index">Index of garden to be edited</param>
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

        /// <summary>
        /// Loads properties of the garden to edit
        /// </summary>
        /// <param name="index">Index of the garden to edit</param>
        private void LoadGardenWhenEditing(int index)
        {
            Garden garden = gardenManager.GetAt(index);

            nameTxtBox.Text = garden.GardenName;
            zoneComboBox.SelectedItem = garden.Zone;
        }

        /// <summary>
        /// If user wants: exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DisplayQuestion("Are you sure? Unsaved changes will be lost", "Are you sure?"))
            {
                this.Close();
            }
        }

        /// <summary>
        /// Loads the zone combobox
        /// </summary>
        private void InitComboBoxes()
        {
            zoneComboBox.ItemsSource = Enum.GetNames(typeof(Enums.GrowZone));
            zoneComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Saves a new garden - or edits an existing one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxtBox.Text;
            Enums.GrowZone zone = (Enums.GrowZone)Enum.Parse(typeof(Enums.GrowZone), zoneComboBox.SelectedItem.ToString()!);

            if (!string.IsNullOrEmpty(name))
            {
                Garden garden = new()
                {
                    GardenName = name,
                    Zone = zone,
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
