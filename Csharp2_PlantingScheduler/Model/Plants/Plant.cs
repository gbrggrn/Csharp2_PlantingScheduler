using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    /// <summary>
    /// Base class for definition of plants
    /// </summary>
    public abstract class Plant
    {
        public Enums.PlantCategory Category { get; set; }

        public Plant() { }
    }
}
