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

namespace Csharp2_PlantingScheduler.Control.Managers
{
    [Serializable]
    public class GardenManager : IObservableCollectionManager<Garden>
    {
        public GardenManager()
        {
            Collection = [];
        }

        //Properties
        public int Count { get; }
        public ObservableCollection<Garden> Collection { get; }

        //Methods
        public void Add(Garden gardenIn)
        {
            Collection.Add(gardenIn);
        }

        public bool Replace(ObservableCollection<Garden> gardenCollectionIn)
        {
            throw new NotImplementedException();
        }

        public void ChangeAt(Garden gardenIn, int index)
        {
            Collection[index] = gardenIn;
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
            return Collection[indexIn];
        }

        public void AddTestValues()
        {
            Garden testGarden = new()
            {
                GardenName = "Veda",
                FirstFrostFreeWeek = 20,
                LastFrostFreeWeek = 41
            };

            Add(testGarden);
        }
    }
}
