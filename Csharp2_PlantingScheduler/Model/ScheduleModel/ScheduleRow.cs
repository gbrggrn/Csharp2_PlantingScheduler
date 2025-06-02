using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.ScheduleModel
{
    internal class ScheduleRow
    {
        public string VegetableTypeDisplay { get; set; } = string.Empty;
        public string VegetableNameDisplay { get; set; } = string.Empty;
        public int WeeksToHarvestDisplay { get; set; }
        public int StartWeek {  get; set; }
        public int EndWeek { get; set; }
    }
}
