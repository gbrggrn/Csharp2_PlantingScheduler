using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Model
{
    public class Enums
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
            Radish,
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
            Zone1 = -4,
            Zone2 = -2,
            Zone3 = -1,
            Zone4 =  0,
            Zone5 = +1,
            Zone6 = +2,
            Zone7 = +3,
            Zone8 = +4,
            Zone9 = +5,
            Mountain = +6
        }

        public enum Months
        {
            Jan,
            Feb,
            Mar,
            Apr,
            May,
            Jun,
            Jul,
            Aug,
            Oct,
            Sep,
            Nov,
            Dec
        }
    }
}
