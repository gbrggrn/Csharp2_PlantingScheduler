using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    /// <summary>
    /// Defines a garden
    /// </summary>
    public class Garden
    {
        public Enums.GrowZone Zone { get; set; }
        public string GardenName { get; set; } = string.Empty;
    }
}
