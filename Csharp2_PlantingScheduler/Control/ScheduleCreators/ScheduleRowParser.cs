using Csharp2_PlantingScheduler.Model;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Flower;
using Csharp2_PlantingScheduler.Model.Plants.TypesOfPlants.Vegetable;
using Csharp2_PlantingScheduler.Model.ScheduleModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.ScheduleCreators
{
    public static class ScheduleRowParser
    {
        public static List<ScheduleRow> ParseToRows(Garden garden, List<Plant> plants)
        {
            List<ScheduleRow> parsedRows = [];

            foreach (Plant plant in plants)
            {
                if (plant is Vegetable veg)
                {
                    if (VegetableDataMap.MetaData.TryGetValue(veg.Type, out VegetableMetaData? metaData))
                    {
                        //Fallback value 0
                        int indoorWeeks = metaData.IndoorWeeks ?? 0;

                        //Extrapolate the rest
                        int startWeek = metaData.BaseStartWeek - indoorWeeks;
                        //Apply zone coefficient
                        startWeek += (int)garden.Zone;
                        int weeksToHarvest = metaData.WeeksToHarvest;
                        int endWeek = startWeek + weeksToHarvest;

                        //If transplanting is at risk of frost damage
                        if (indoorWeeks != 0 && startWeek + indoorWeeks < garden.FirstFrostFreeWeek)
                        {
                            int frostOffset = garden.FirstFrostFreeWeek - (startWeek + indoorWeeks);

                            startWeek += frostOffset;
                            endWeek += frostOffset;
                        }

                        //Create a schedule row
                        ScheduleRow scheduleRow = new()
                        {
                            TypeDisplay = veg.Type.ToString(),
                            NameDisplay = veg.SpeciesName,
                            WeeksToHarvestDisplay = weeksToHarvest,
                            StartWeek = startWeek,
                            EndWeek = endWeek,
                            IndoorWeeks = indoorWeeks
                        };

                        //Add row to list of parsed rows
                        parsedRows.Add(scheduleRow);
                    }
                }
                else if (plant is Flower flower)
                {
                    //TODO
                }
            }

            return parsedRows;
        }
    }
}
