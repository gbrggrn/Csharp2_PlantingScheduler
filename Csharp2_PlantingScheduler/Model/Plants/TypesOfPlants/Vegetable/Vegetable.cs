using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable
{
    /// <summary>
    /// Defines a vegetable
    /// </summary>
    public class Vegetable : Plant
    {
        public string SpeciesName { get; set; } = string.Empty;
        public Enums.VegetableType Type { get; set; }
        public Enums.SowType SowType { get; set; }

        public int BaseStartWeek { get; set; }
        public int WeeksToHarvest { get; set; }
        public int? IndoorWeeks { get; set; }
        public int? ColdStartWeeks { get; set; }

        public Vegetable() { }
    }
}
