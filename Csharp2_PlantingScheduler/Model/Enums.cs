using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    class Enums
    {
        public enum PlantCategory
        {
            None,
            Leafy,
            Fruiting,
            Root,
            Ornamental,
            Medicinal
        }

        public enum GrowthType
        {
            Annual,
            Perennieal,
            Biennial
        }

        public enum SowType
        {
            Coldstart,
            Indoorstart,
            Directsow
        }

        public enum VegetableType
        {
            Unknown,
            Onion,
            Aubergine,
            Beet,
            Cucumber,
            Tomato,
            Kale,
            Cabbage,
            Carrot,
            Salad,
            Leaf,
            Pumpkin,
            Radish,
            Squash,
            Zucchini,
            Chili,
            Pepper,
            Pea,
            Bean,
            Herb
        }

        public enum GrowZone
        {
            Zone1,
            Zone2,
            Zone3,
            Zone4,
            Zone5,
            Zone6,
            Zone7,
            Zone8,
            Zone9,
            Mountain
        }
    }
}
