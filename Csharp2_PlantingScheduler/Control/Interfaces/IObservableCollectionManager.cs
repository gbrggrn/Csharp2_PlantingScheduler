using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Interfaces
{
    class IObservableCollectionManager<T>
    {
        void Add(T item) { }
        void Remove(int index, T item) { }
        void Edit(int index, T item) { }
    }
}
