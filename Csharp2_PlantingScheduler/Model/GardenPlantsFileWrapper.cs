using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Flower;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    [Serializable]
    public class GardenPlantsFileWrapper
    {
        public List<Garden> Gardens { get; set; }
        public List<Vegetable> Vegs { get; set; }
        public List<Flower> Flowers { get; set; }

        public GardenPlantsFileWrapper()
        {
            Gardens = [];
            Vegs = [];
            Flowers = [];
        }
    }
}
