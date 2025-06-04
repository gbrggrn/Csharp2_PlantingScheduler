using Csharp2_PlantingScheduler.Control.Managers;
using Csharp2_PlantingScheduler.Helpers;
using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Flower;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable;
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
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        private PlantManager plantManager;
        private int nameMaxChar = 30;
        private bool editingFlag = false;
        private int editingIndex;

        public PlantWindow(PlantManager currentPlantManager)
        {
            InitializeComponent();
            plantManager = currentPlantManager;
            categoryComboBox.SelectionChanged += SwitchTypesComboBox;
            InitComboBoxes();
        }

        public PlantWindow(PlantManager currentPlantManager, int index)
        {
            InitializeComponent();
            plantManager = currentPlantManager;
            editingIndex = index;
            categoryComboBox.SelectionChanged += SwitchTypesComboBox;
            InitComboBoxes();
            LoadPlantWhenEditing(editingIndex);
            windowName.Content = "Editing Plant";
        }

        private void LoadPlantWhenEditing(int index)
        {
            editingFlag = true;
            Plant plant = plantManager.GetAt(index);

            if (plant is Vegetable veg)
            {
                categoryComboBox.SelectedItem = veg.Category;
                growthTypeComboBox.SelectedItem = veg.GrowthType;
                sowTypeComboBox.SelectedItem = veg.SowType;
                nameTxtBox.Text = veg.SpeciesName;
            }
            else if (plant is Flower flower)
            {
                //TO DO
            }
        }

        private void InitComboBoxes()
        {
            categoryComboBox.ItemsSource = Enum.GetNames(typeof(Enums.PlantCategory));
            growthTypeComboBox.ItemsSource = Enum.GetNames(typeof(Enums.GrowthType));
            sowTypeComboBox.ItemsSource = Enum.GetNames(typeof(Enums.SowType));

            categoryComboBox.SelectedIndex = 1;
            growthTypeComboBox.SelectedIndex = 0;
            sowTypeComboBox.SelectedIndex = 0;
        }

        private void SwitchTypesComboBox(object sender, RoutedEventArgs e)
        {
            if (categoryComboBox.SelectedIndex == 1)
            {
                typeComboBox.ItemsSource = Enum.GetNames(typeof(Enums.VegetableType));
            }
            else
            {
                typeComboBox.ItemsSource = Enum.GetNames(typeof(Enums.FlowerType));
            }

            typeComboBox.SelectedIndex = 0;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxes.DisplayQuestion("Are you sure? Unsaved changes will be lost", "Are you sure?"))
            {
                this.Close();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = nameTxtBox.Text;

            if (!string.IsNullOrEmpty(name) && name.Length <= nameMaxChar)
            {
                if (categoryComboBox.SelectedIndex == 1)
                {
                    Vegetable vegetable = new()
                    {
                        SpeciesName = name,
                        Category = (Enums.PlantCategory)Enum.Parse(typeof(Enums.PlantCategory), categoryComboBox.SelectedItem.ToString()!),
                        GrowthType = (Enums.GrowthType)Enum.Parse(typeof(Enums.GrowthType), growthTypeComboBox.SelectedItem.ToString()!),
                        SowType = (Enums.SowType)Enum.Parse(typeof(Enums.SowType), sowTypeComboBox.SelectedItem.ToString()!),
                        Type = (Enums.VegetableType)Enum.Parse(typeof(Enums.VegetableType), typeComboBox.SelectedItem.ToString()!)
                    };

                    if (editingFlag)
                    {
                        plantManager.ChangeAt(vegetable, editingIndex);
                    }
                    else
                    {
                        plantManager.Add(vegetable);
                    }

                    MessageBoxes.DisplayInfoBox($"The {vegetable.Type.ToString()} {vegetable.SpeciesName} added!", "Success!");
                }
            }
            else
            {
                MessageBoxes.DisplayErrorBox($"Name can not be empty and max {nameMaxChar} characters");
            }
        }
    }
}
