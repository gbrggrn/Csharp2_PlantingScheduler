using Csharp2_PlantingScheduler.Control.Interfaces;
using Csharp2_PlantingScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Managers
{
    public class GardenManager : IObservableCollectionManager<Garden>
    {
        public GardenManager()
        {
            Collection = [];
        }

        //Properties
        public int Count => Collection.Count;
        public ObservableCollection<Garden> Collection { get; }

        //Methods
        public void Add(Garden gardenIn)
        {
            Collection.Add(gardenIn);
        }

        public void ChangeAt(Garden gardenIn, int index)
        {
            Collection[index] = gardenIn;
        }

        public void DeleteAll()
        {
            Collection.Clear();
        }

        public void DeleteAt(int index)
        {
            Collection.RemoveAt(index);
        }

        public Garden GetAt(int indexIn)
        {
            return Collection[indexIn];
        }

        /*public void AddTestValues()
        {
            Garden testGarden = new()
            {
                GardenName = "Veda"
            };

            Add(testGarden);
        }*/
    }
}
