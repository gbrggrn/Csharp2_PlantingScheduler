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
    /// <summary>
    /// Handles all file operations
    /// </summary>
    class FileManager
    {
        //Manager access
        private readonly PlantManager plantManager;
        private readonly GardenManager gardenManager;

        /// <summary>
        /// Constructor assigns access to current managers
        /// </summary>
        /// <param name="plantManager">The current instance of plantManager</param>
        /// <param name="gardenManager">The current instance of gardenManager</param>
        public FileManager(PlantManager plantManager, GardenManager gardenManager)
        {
            this.plantManager = plantManager;
            this.gardenManager = gardenManager;
        }

        /// <summary>
        /// Serializes plants and gardens in a wrapper-class
        /// </summary>
        /// <param name="filePath">The file path to serialize to</param>
        /// <exception cref="ArgumentException">Throws if serialization fails</exception>
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
                using StreamWriter write = new(filePath);
                string jsonString = JsonSerializer.Serialize(wrap);

                write.Write(jsonString);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong - File not saved\n" +
                    $"Errormessage:\n" +
                    $"{ex.Message}");
            }
        }

        /// <summary>
        /// Deserializes wrapper and calls unwrapping
        /// </summary>
        /// <param name="filePath">The file path of the file to deserialize</param>
        /// <exception cref="ArgumentException">Throws if deserialization fails</exception>
        public void Deserialize(string filePath)
        {
            GardenPlantsFileWrapper wrapped = new();

            try
            {
                using StreamReader read = new(filePath);
                string jsonString = read.ReadToEnd();
                wrapped = JsonSerializer.Deserialize<GardenPlantsFileWrapper>(jsonString)!;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Something went wrong - File not loaded\n" +
                    $"Errormessage:\n" +
                    $"{ex.Message}");
            }

            UnwrapData(wrapped);
        }

        /// <summary>
        /// Unwraps the wrapped data and adds it back to the collections
        /// </summary>
        /// <param name="wrapped">The wrapper to unwrap</param>
        private void UnwrapData(GardenPlantsFileWrapper wrapped)
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
            }
        }
    }
}
