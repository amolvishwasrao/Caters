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

        private bool _IsMashroom;

        public bool IsMashroom
        {
            get { return _IsMashroom; }
            set { _IsMashroom = value; OnPropertyRaised("IsMashroom"); }
        }


        private List<CustomizationOption> _PizzaSandwitchCustomOptions;
            
        public List<CustomizationOption> PizzaSandwitchCustomOptions
        {
            get { return _PizzaSandwitchCustomOptions; }
            set { _PizzaSandwitchCustomOptions = value; OnPropertyRaised("PizzaSandwitchCustomOptions"); }
        }



        private int _MashroomCount;

        public int MashroomCount
        {
            get { return _MashroomCount; }
            set { _MashroomCount = value; OnPropertyRaised("MashroomCount");  }
        }

        private ObservableCollection<int> _MashroomsCustomNos;

        public ObservableCollection<int> MashroomsCustomNos
        {
            get { return _MashroomsCustomNos; }
            set { _MashroomsCustomNos = value; OnPropertyRaised("MashroomsCustomNos"); }
        }

        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set { _SelectedIndex = value; }
        }




        private List<Caters.Model.Customize.Cutomize> _Customizations;

        public List<Caters.Model.Customize.Cutomize> Customizations
        {
            get { return _Customizations; }
            set { _Customizations = value; }
        }


        private List<Caters.Model.Common.Food> _Foods;

        public List< Caters.Model.Common.Food> Foods
        {
            get { return _Foods; }
            set { _Foods = value; }
        }

        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get;
            set;
        }

        private ICommand _SubCommand;
        public ICommand SubCommand
        {
            get;
            set;
        }




        public OrderPlacementViewModel()
        {
            MashroomCount = 0;
            AddCommand = new RelayCommand.RelayCommand(
                AddMethod);
            SubCommand = new RelayCommand.RelayCommand(
                SubMethod);
            Foods = new List<Model.Common.Food>();
            PizzaSandwitchCustomOptions = new List<CustomizationOption>();
            addDummyData();
            
        }

        private void addDummyData()
        {
            PizzaSandwitchCustomOptions.Add( new CustomizationOption() { IsSelect=false,Name="BrownBread"});
            PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "WhiteBread" });
            PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "CheeseTopping" });
            PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "SauceBread" });
        }

        private void AddMethod(object obj)
        {
            Caters.Model.Factory.FoodFactory food; 
            if ((string)obj == "Mashroom")
            {
                MashroomsCustomNos = new ObservableCollection<int>();
                food = new  Model.Factory.PizzaFactory.MashroomFactory();
                Foods.Add(food.GetFood());
                MashroomCount++;
                AddDropDown(MashroomCount);
            }
             
        }

        private void SubMethod( object obj)
        {
            
            if ((string)obj == "Mashroom")
            {
                if (MashroomCount > 0)
                {
                    MashroomCount--;
                    MashroomsCustomNos.RemoveAt(MashroomsCustomNos.Count - 1);
                }
               
            }
        }

        private void AddDropDown(int MashroomCount)
        {
            MashroomsCustomNos.Clear();
            for (int i =1; i <= _MashroomCount; i++)
            {
                MashroomsCustomNos.Add(i);
            }
        }

    

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }

    public class CustomizationOption:INotifyPropertyChanged
    {
        private bool _IsSelect;

        public bool IsSelect
        {
            get { return _IsSelect; }
            set { _IsSelect = value; OnPropertyRaised("IsSelect"); }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
