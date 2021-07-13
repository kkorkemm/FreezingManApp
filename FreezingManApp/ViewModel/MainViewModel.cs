using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreezingManApp.ViewModel
{
    using MVVMCore;

    class MainViewModel : INotify
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value;
                OnPropertyChanged();
            }
        }


        public ListViewModel ListVM { get; set; }
        public MapViewModel MapVM { get; set; }


        public BaseCommand ListCommand { get; set; }
        public BaseCommand MapCommand { get; set; }


        public MainViewModel()
        {
            ListVM = new ListViewModel();
            MapVM = new MapViewModel();

            CurrentView = ListVM;

            ListCommand = new BaseCommand(o =>
            {
                CurrentView = ListVM;
            });

            MapCommand = new BaseCommand(o =>
            {
               CurrentView = MapVM;
            });
        }
    }
}
