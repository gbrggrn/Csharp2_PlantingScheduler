using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Interfaces
{
    internal interface IObservableCollectionManager<T>
    {
        //Methods
        void Add(T type);
        bool Replace(ObservableCollection<T> collectionIn);
        void ChangeAt(T type, int indexIn);
        bool CheckIndex(int indexIn);
        void DeleteAll();
        bool DeleteAt(T typeIn);
        T GetAt(int indexIn);

        //Properties
        int Count { get; }
        ObservableCollection<T> Collection { get; }
    }
}
