using Csharp2_PlantingScheduler.Control.Interfaces;
using Csharp2_PlantingScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control
{
    class PlantManager : IObservableCollectionManager<Plant>
    {
        public PlantManager()
        {
            Collection = new ObservableCollection<Plant>();
        }

        //Properties
        public int Count { get; }
        public ObservableCollection<Plant> Collection { get; }

        //Methods
        public bool Add(Plant plantIn) 
        {
            throw new NotImplementedException();
        }

        public bool Replace(ObservableCollection<Plant> plantCollectionIn)
        {
            throw new NotImplementedException();
        }

        public bool ChangeAt(Plant plantIn, int index)
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

        public bool DeleteAt(Plant plantIn)
        {
            throw new NotImplementedException();
        }

        public Plant GetAt(int indexIn)
        {
            throw new NotImplementedException();
        }
    }
}
