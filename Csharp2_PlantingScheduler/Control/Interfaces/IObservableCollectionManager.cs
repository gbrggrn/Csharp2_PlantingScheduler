using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp2_PlantingScheduler.Control.Interfaces
{
    /// <summary>
    /// Interface for observablecollections in managers
    /// </summary>
    /// <typeparam name="T">Type the collection holds</typeparam>
    public interface IObservableCollectionManager<T>
    {
        //Methods
        void Add(T type);
        void ChangeAt(T type, int indexIn);
        void DeleteAll();
        void DeleteAt(int index);
        T GetAt(int indexIn);

        //Properties
        int Count { get; }
        ObservableCollection<T> Collection { get; }
    }
}
