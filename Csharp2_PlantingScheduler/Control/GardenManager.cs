using Csharp2_PlantingScheduler.Control.Interfaces;
using Csharp2_PlantingScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control
{
    [Serializable]
    class GardenManager : IObservableCollectionManager<Garden>
    {
        public GardenManager()
        {
            Collection = new ObservableCollection<Garden>();
        }

        //Properties
        public int Count { get; }
        public ObservableCollection<Garden> Collection { get; }

        //Methods
        public bool Add(Garden gardenIn)
        {
            throw new NotImplementedException();
        }

        public bool Replace(ObservableCollection<Garden> gardenCollectionIn)
        {
            throw new NotImplementedException();
        }

        public bool ChangeAt(Garden gardenIn, int index)
        {
            throw new NotImplementedException();
        }

        public bool CheckIndex(int indexIn)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool DeleteAt(Garden gardenIn)
        {
            throw new NotImplementedException();
        }

        public Garden GetAt(int indexIn)
        {
            throw new NotImplementedException();
        }
    }
}
