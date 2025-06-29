﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Flower
{
    /// <summary>
    /// Defines a flower - not yet implemented fully
    /// </summary>
    public class Flower : Plant
    {
        public string SpeciesName { get; set; } = string.Empty;
        public Enums.FlowerType FlowerType { get; set; }
        public Enums.SowType SowType { get; set; }

        public Flower() { }
    }
}
