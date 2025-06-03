using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    public class Plant
    {
        public string Name { get; set; } = string.Empty;
        public Enums.PlantCategory Category { get; set; }
        public Enums.GrowthType GrowthType { get; set; }
    }
}
