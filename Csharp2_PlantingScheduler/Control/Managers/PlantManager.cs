using Csharp2_PlantingScheduler.Control.Interfaces;
using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Managers
{
    public class PlantManager : IObservableCollectionManager<Plant>
    {
        public PlantManager()
        {
            Collection = [];
        }

        //Properties
        public int Count => Collection.Count;
        public ObservableCollection<Plant> Collection { get; }

        //Methods
        public void Add(Plant plantIn)
        {
            Collection.Add(plantIn);
        }

        public void ChangeAt(Plant plantIn, int index)
        {
            Collection[index] = plantIn;
        }

        public void DeleteAll()
        {
            Collection.Clear();
        }

        public void DeleteAt(int index)
        {
            Collection.RemoveAt(index);
        }

        public Plant GetAt(int indexIn)
        {
            return Collection[indexIn];
        }

        /*public void AddTestValues()
        {
            Vegetable veg1 = new()
            {
                Category = Enums.PlantCategory.Vegetable,
                GrowthType = Enums.GrowthType.Annual,
                SpeciesName = "Nero",
                Type = Enums.VegetableType.Kale,
                SowType = Enums.SowType.Coldstart
            };

            Vegetable veg2 = new()
            {
                Category = Enums.PlantCategory.Vegetable,
                GrowthType = Enums.GrowthType.Annual,
                SpeciesName = "Detroit 2",
                Type = Enums.VegetableType.Beet,
                SowType = Enums.SowType.Directsow
            };

            Vegetable veg3 = new()
            {
                Category = Enums.PlantCategory.Vegetable,
                GrowthType = Enums.GrowthType.Annual,
                SpeciesName = "Lollo Rossa",
                Type = Enums.VegetableType.Salad,
                SowType = Enums.SowType.Coldstart
            };

            Vegetable veg4 = new()
            {
                Category = Enums.PlantCategory.Vegetable,
                GrowthType = Enums.GrowthType.Annual,
                SpeciesName = "Långböna",
                Type = Enums.VegetableType.Bean,
                SowType = Enums.SowType.Coldstart
            };

            Vegetable veg5 = new()
            {
                Category = Enums.PlantCategory.Vegetable,
                GrowthType = Enums.GrowthType.Annual,
                SpeciesName = "Brandywine Yellow",
                Type = Enums.VegetableType.Tomato,
                SowType = Enums.SowType.Indoorstart
            };

            Add(veg1);
            Add(veg2);
            Add(veg3);
            Add(veg4);
            Add(veg5);
        }*/
    }
}
