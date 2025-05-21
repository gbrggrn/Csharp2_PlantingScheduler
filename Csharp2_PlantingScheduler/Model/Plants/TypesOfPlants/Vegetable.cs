using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    class Vegetable : Plant
    {
        public string SpeciesName { get; set; } = string.Empty;
        public Enums.VegetableType Type { get; set; }
        public int WeeksToHarvest { get; set; }
        public Enums.SowType SowType { get; set; }
        public bool IsFrostTolerant { get; set; }
        public int MaxNegativeDegrees { get; set; }
        public bool ShouldStartIndoors { get; set; }
        public bool NeedsTransplant { get; set; }
        public int AmountOfTransplants { get; set; }
        public bool ShouldTrellis { get; set; }
        public int TrellisIntervalInWeeks { get; set; }
    }
}
