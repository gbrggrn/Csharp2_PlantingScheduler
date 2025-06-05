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
                    int indoorWeeks = veg.IndoorWeeks ?? 0;
                    int coldStartWeeks = veg.ColdStartWeeks ?? 0;

                    int firstFrostFreeWeek = (int)garden.Zone;

                    int startWeek;
                    if (indoorWeeks > 0)
                    {
                        startWeek = firstFrostFreeWeek - indoorWeeks;
                    }
                    else if (coldStartWeeks > 0)
                    {
                        startWeek = firstFrostFreeWeek - coldStartWeeks;
                    }
                    else
                    {
                        startWeek = firstFrostFreeWeek;
                    }

                    int weeksToHarvest = veg.WeeksToHarvest;
                    int endWeek = startWeek + weeksToHarvest;

                    ScheduleRow scheduleRow = new()
                    {
                        TypeDisplay = veg.Type.ToString(),
                        NameDisplay = veg.SpeciesName,
                        WeeksToHarvestDisplay = weeksToHarvest,
                        StartWeek = startWeek,
                        EndWeek = endWeek,
                        IndoorWeeks = indoorWeeks,
                        ColdStartWeeks = coldStartWeeks
                    };

                    parsedRows.Add(scheduleRow);
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
