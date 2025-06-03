using Csharp2_PlantingScheduler.Control.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Csharp2_PlantingScheduler
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        private PlantManager plantManager;

        public PlantWindow(PlantManager currentPlantManager)
        {
            InitializeComponent();
            plantManager = currentPlantManager;
        }


    }
}
