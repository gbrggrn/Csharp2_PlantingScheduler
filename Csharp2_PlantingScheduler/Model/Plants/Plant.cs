using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    public abstract class Plant
    {
        public Enums.PlantCategory Category { get; set; }
        public Enums.GrowthType GrowthType { get; set; }

        public Plant() { }
    }
}
