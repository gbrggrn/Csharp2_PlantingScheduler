using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable
{
    public static class VegetableDataMap
    {
        public static readonly Dictionary<Enums.VegetableType, VegetableMetaData> MetaData = new()
        {
            { Enums.VegetableType.Unknown, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 10} },
            { Enums.VegetableType.Radish, new VegetableMetaData {BaseStartWeek = 9, WeeksToHarvest = 5} },
            { Enums.VegetableType.Leaf, new VegetableMetaData {BaseStartWeek = 9, WeeksToHarvest = 5 } },
            { Enums.VegetableType.Salad, new VegetableMetaData {BaseStartWeek = 13, WeeksToHarvest = 9} },
            { Enums.VegetableType.Tomato, new VegetableMetaData {BaseStartWeek = 9, WeeksToHarvest = 16} },
            { Enums.VegetableType.Cucumber, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 10 } },
            { Enums.VegetableType.Cabbage, new VegetableMetaData {BaseStartWeek = 13, WeeksToHarvest = 14 } },
            { Enums.VegetableType.Aubergine, new VegetableMetaData {BaseStartWeek = 8, WeeksToHarvest = 18} },
            { Enums.VegetableType.Bean, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 9 } },
            { Enums.VegetableType.Beet, new VegetableMetaData {BaseStartWeek = 13, WeeksToHarvest = 10} },
            { Enums.VegetableType.Carrot, new VegetableMetaData {BaseStartWeek = 13, WeeksToHarvest = 12} },
            { Enums.VegetableType.Kale, new VegetableMetaData {BaseStartWeek = 13, WeeksToHarvest = 10} },
            { Enums.VegetableType.Onion, new VegetableMetaData {BaseStartWeek = 5 , WeeksToHarvest = 18} },
            { Enums.VegetableType.Pea, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 9 } },
            { Enums.VegetableType.Pepper, new VegetableMetaData {BaseStartWeek = 5, WeeksToHarvest = 18 } },
            { Enums.VegetableType.Pumpkin, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 18} },
            { Enums.VegetableType.Zucchini, new VegetableMetaData {BaseStartWeek = 16, WeeksToHarvest = 9} },
            { Enums.VegetableType.Squash, new VegetableMetaData {BaseStartWeek = 16, WeeksToHarvest = 9} },
            { Enums.VegetableType.Herb, new VegetableMetaData {BaseStartWeek = 15, WeeksToHarvest = 7} }
        };
    }
}
