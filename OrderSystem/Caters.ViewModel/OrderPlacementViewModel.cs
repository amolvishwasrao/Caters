using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Caters.Model;
using Caters.Model.Customize;

namespace Caters.ViewModel
{
    public class OrderPlacementViewModel:INotifyPropertyChanged
    {

        private int _MashroomCount;

        public int MashroomCount
        {
            get { return _MashroomCount; }
            set { _MashroomCount = value; OnPropertyRaised("MashroomCount"); }
        }


        private ICommand _AddCommand;

        private List<Caters.Model.Common.Food> _Foods;

        public event PropertyChangedEventHandler PropertyChanged;

        public List< Caters.Model.Common.Food> Foods
        {
            get { return _Foods; }
            set { _Foods = value; }
        }

        public ICommand AddCommand
        {
            get;
            set;
        }

       

        public OrderPlacementViewModel()
        {
            MashroomCount = 0;
            AddCommand = new RelayCommand.RelayCommand(
                AddMethod);
            
        }

        private void AddMethod(object obj)
        {
            MashroomCount++;   
        }

        private void LoadDefaultData()  
        {
            Caters.Model.Common.Food food;
            List<Caters.Model.Common.Food> foods = new List<Model.Common.Food>();

            food = new Model.Pizza.Mashroom();
            foods.Add(food);
            foods.Add(food);
            Foods = foods;
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
