using Csharp2_PlantingScheduler.Control.Observers;
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
    internal class ScheduleRowParser
    {
        private Garden garden;
        private List<Plant> plants;

        public ScheduleRowParser(Garden gardenIn, List<Plant> plantsIn)
        {
            garden = gardenIn;
            plants = plantsIn;
        }

        private List<ScheduleRow> ParseToRows()
        {
            List<ScheduleRow> parsedRows = [];

            foreach (Plant plant in plants)
            {
                if (plant is Vegetable veg)
                {
                    int startWeek = 0;
                    int endWeek = 0;
                    int weeksToHarvest = 0;

                    if (VegetableDataMap.MetaData.TryGetValue(veg.Type, out VegetableMetaData metaData))
                    {
                        startWeek = metaData.BaseStartWeek;
                        endWeek = startWeek + metaData.WeeksToHarvest;
                        weeksToHarvest = metaData.WeeksToHarvest;
                    }

                    //Add zone coefficient
                    startWeek += (int)garden.Zone;
                    endWeek += (int)garden.Zone;

                    //Create a schedule row
                    ScheduleRow scheduleRow = new()
                    {
                        VegetableTypeDisplay = veg.Type.ToString(),
                        VegetableNameDisplay = veg.SpeciesName,
                        WeeksToHarvestDisplay = weeksToHarvest,
                        StartWeek = startWeek,
                        EndWeek = endWeek
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
