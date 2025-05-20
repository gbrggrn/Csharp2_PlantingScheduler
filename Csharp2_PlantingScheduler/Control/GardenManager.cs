using Csharp2_PlantingScheduler.Control.Interfaces;
using Csharp2_PlantingScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control
{
    class GardenManager : IObservableCollectionManager<Garden>
    {
        private ObservableCollection<Garden> gardens;

        public ObservableCollection<Garden> Gardens { get => gardens; }
    }
}
