using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp2_PlantingScheduler.Model;

namespace Csharp2_PlantingScheduler.Control.Observers
{
    class GardensPlantsObserver
    {
        public ObservableCollection<Garden> Gardens { get; set; }
        public ObservableCollection<Plant> Plants { get; set; }

        public GardensPlantsObserver(GardenManager gardenManagerIn, PlantManager plantManagerIn)
        {
            Gardens = gardenManagerIn.Collection;
            Plants = plantManagerIn.Collection;
        }
    }
}
