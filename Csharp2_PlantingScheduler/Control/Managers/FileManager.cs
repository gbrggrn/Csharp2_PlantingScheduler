using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Flower;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Managers
{
    class FileManager
    {
        private PlantManager plantManager;
        private GardenManager gardenManager;

        public FileManager(PlantManager plantManager, GardenManager gardenManager)
        {
            this.plantManager = plantManager;
            this.gardenManager = gardenManager;
        }

        public void Serialize(string filePath)
        {
            GardenPlantsFileWrapper wrap = new();

            foreach (var plant in plantManager.Collection)
            {
                if (plant is Vegetable veg)
                {
                    wrap.Vegs.Add(veg);
                }
                else if (plant is Flower flower)
                {
                    wrap.Flowers.Add(flower);
                }
            }

            wrap.Gardens = gardenManager.Collection.ToList();

            try
            {
                using (StreamWriter write = new(filePath))
                {
                    string jsonString = JsonSerializer.Serialize(wrap);

                    write.Write(jsonString);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong - File not saved\n" +
                    $"Errormessage:\n" +
                    $"{ex.Message}");
            }
        }

        public void Deserialize(string filePath)
        {
            GardenPlantsFileWrapper wrapped = new();

            try
            {
                using (StreamReader read = new(filePath))
                {
                    string jsonString = read.ReadToEnd();
                    wrapped = JsonSerializer.Deserialize<GardenPlantsFileWrapper>(jsonString)!;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong - File not loaded\n" +
                    $"Errormessage:\n" +
                    $"{ex.Message}");
            }

            UnwrapData(wrapped);
        }

        private bool UnwrapData(GardenPlantsFileWrapper wrapped)
        {
            if (wrapped != null)
            {
                foreach (var plant in wrapped.Vegs)
                {
                    plantManager.Add(plant);
                }

                foreach (var plant in wrapped.Flowers)
                {
                    plantManager.Add(plant);
                }

                foreach (Garden garden in wrapped.Gardens)
                {
                    gardenManager.Add(garden);
                }

                return true;
            }

            return false;
        }
    }
}
