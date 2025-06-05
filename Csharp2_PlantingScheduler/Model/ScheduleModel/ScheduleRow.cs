using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.ScheduleModel
{
    public class ScheduleRow
    {
        public string TypeDisplay { get; set; } = string.Empty;
        public string NameDisplay { get; set; } = string.Empty;
        public int WeeksToHarvestDisplay { get; set; }
        public int StartWeek {  get; set; }
        public int EndWeek { get; set; }
        public int IndoorWeeks { get; set; } = 0;
        public int ColdStartWeeks { get; set; } = 0;
    }
}
