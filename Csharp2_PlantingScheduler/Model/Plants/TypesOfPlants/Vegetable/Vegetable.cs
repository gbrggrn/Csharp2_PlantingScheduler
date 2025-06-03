using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable
{
    class Vegetable : Plant
    {
        public string SpeciesName { get; set; } = string.Empty;
        public Enums.VegetableType Type { get; set; } = Enums.VegetableType.Unknown;
        public Enums.SowType SowType { get; set; }
    }
}
