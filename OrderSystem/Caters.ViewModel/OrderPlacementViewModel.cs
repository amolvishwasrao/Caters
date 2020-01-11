using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Caters.Model;
using Caters.Model.Customize;
using Caters.Model.Order;

namespace Caters.ViewModel
{  
    public class OrderPlacementViewModel:INotifyPropertyChanged
    {

        #region Constructor
        public OrderPlacementViewModel()
        {
            MashroomCount = 0;
            PannerCount = 0;
            SevenUpCount = 0;
            Order = new Model.Order.Order();
            AddCommand = new RelayCommand.RelayCommand(
                AddMethod);
            SubCommand = new RelayCommand.RelayCommand(
                SubMethod);
            CustomCommand = new RelayCommand.RelayCommand(Custom);
            AddOrderCommand = new RelayCommand.RelayCommand(AddCustomToOrder);
            Foods = new ObservableCollection<Model.Common.Food>();
            PizzaSandwitchCustomOptions = new List<CustomizationOption>();

        } 
        #endregion

        private Model.Order.Order _Order;

        public Order Order
        {
            get
            {
                return _Order;
            }
            set
            {
                _Order = value;
                OnPropertyRaised("Order");
                CustomMessage();

            }
        }


        private bool _IsMashroom;

        public bool IsMashroom
        {
            get { return _IsMashroom; }
            set { _IsMashroom = value; OnPropertyRaised("IsMashroom"); }
        }

        private bool _IsPanner;

        public bool IsPanner
        {
            get { return _IsPanner; }
            set { _IsPanner = value; OnPropertyRaised("IsPanner"); }
        }


        private bool _IsSevenUp;

        public bool IsSevenUp
        {
            get { return _IsSevenUp; }
            set { _IsSevenUp = value; OnPropertyRaised("IsSevenUp"); }
        }



        private List<CustomizationOption> _PizzaSandwitchCustomOptions;
            
        public List<CustomizationOption> PizzaSandwitchCustomOptions
        {
            get { return _PizzaSandwitchCustomOptions; }
            set { _PizzaSandwitchCustomOptions = value; }//OnPropertyRaised("PizzaSandwitchCustomOptions"); 
        }


        private int _MashroomCount;
        public int MashroomCount
        {
            get { return _MashroomCount; }
            set { _MashroomCount = value; OnPropertyRaised("MashroomCount");  }
        }


        private int _PannerCount;
        public int PannerCount
        {
            get { return _PannerCount; }
            set { _PannerCount = value; OnPropertyRaised("PannerCount"); }
        }

        private int _SevenUpCount;
        public int SevenUpCount
        {
            get { return _SevenUpCount; }
            set { _SevenUpCount = value; OnPropertyRaised("SevenUpCount"); }
        }
        //BombayCount

        private ObservableCollection<int> _MashroomsCustomNos;

        public ObservableCollection<int> MashroomsCustomNos
        {
            get { return _MashroomsCustomNos; }
            set { _MashroomsCustomNos = value; OnPropertyRaised("MashroomsCustomNos"); ResetSelection(); }
        }

        private void ResetSelection()
        {
            if (PizzaSandwitchCustomOptions == null) return;
            foreach (var item in PizzaSandwitchCustomOptions)
                item.IsSelect = false;
            
        }

        private ObservableCollection<int> _PannerCustomNos;

        public ObservableCollection<int> PannerCustomNos
        {
            get { return _PannerCustomNos; }
            set { _PannerCustomNos = value; OnPropertyRaised("PannerCustomNos"); ResetSelection(); }
        }

        private ObservableCollection<int> _SevenUpCustomNos;

        public ObservableCollection<int> SevenUpCustomNos
        {
            get { return _SevenUpCustomNos; }
            set { _SevenUpCustomNos = value; OnPropertyRaised("SevenUpCustomNos"); ResetSelection(); }
        }


        private int _SelectedIndex;

        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set { _SelectedIndex = value; OnPropertyRaised("SelectedIndex"); }
        }

        private List<Caters.Model.Customize.Cutomize> _Customizations;

        public List<Caters.Model.Customize.Cutomize> Customizations
        {
            get { return _Customizations; }
            set { _Customizations = value; }
        }


        private ObservableCollection<Caters.Model.Common.Food> _Foods;

        public ObservableCollection< Caters.Model.Common.Food> Foods
        {
            get { return _Foods; }
            set { _Foods = value; }
        }

        #region Command Add,Sub,Custom
        private ICommand _AddCommand;
        public ICommand AddCommand
        {
            get;
            set;
        }

        private ICommand _CustomCommand;
        public ICommand CustomCommand
        {
            get;
            set;
        }


        private ICommand _AddOrderCommand;
        public ICommand AddOrderCommand
        {
            get;
            set;
        }
        //AddOrderCommand

        private ICommand _SubCommand;
        public ICommand SubCommand
        {
            get;
            set;
        }

        private string _CustomMessageString;

        public string CustomMessageString
        {
            get { return _CustomMessageString; }
            set { _CustomMessageString = value;OnPropertyRaised("CustomMessageString"); }
        }


        #endregion

        private void CustomMessage()
        {
            CustomMessageString = string.Empty;

            if (Foods == null) return;
            
            try
            {
                foreach (var item in Foods)
                {
                    CustomMessageString = "   "+ CustomMessageString + item.TypeOfFood + "of base price " + item.price + Environment.NewLine;
                    foreach (var initem in item.Customization)
                    {
                        CustomMessageString = CustomMessageString + "Custom-" + initem.CustomizeName + " withprice " + initem.price + Environment.NewLine + Environment.NewLine;
                    }
                    
                       
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }

        #region Command on selection change of Choice from UI
        private void Custom(object obj)
        {
            try
            {
                string temp = ((CheckBox)obj).Tag.ToString();

                Caters.Model.Factory.CustomizesFactory customizefood = null;

                AddCustomizationToFood(customizefood, Foods, temp);
                CustomMessage();
            }
            catch (Exception ex)
            {

                throw;
            }
           

        } 
        #endregion

        #region Adding Customizaion of user into the selected item in Cart
        private void AddCustomizationToFood(Caters.Model.Factory.CustomizesFactory customizefood, ObservableCollection<Caters.Model.Common.Food> Foods, string compare)
        {
            if (SelectedIndex == 0) return;
            try
            {
                Caters.Model.Common.Food tempfood = Foods.Where(p => p.TypeOfFood.Contains(compare as string)).ToList()[SelectedIndex - 1];

                foreach (var item in PizzaSandwitchCustomOptions)
                {

                    if (item.Name.Contains("Brown"))
                    {
                        if (item.IsSelect)
                        {
                            if (!tempfood.Customization.OfType<Caters.Model.Customize.BrownBread>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.BrownBreadFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }

                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.BrownBread>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.BrownBread>().First());
                        }

                    }
                    else if (item.Name.Contains("Softy"))
                    {
                        if (item.IsSelect)
                        {
                            if (!tempfood.Customization.OfType<Caters.Model.Customize.Softy>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.SoftyFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }

                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.Softy>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.Softy>().First());
                        }
                    }
                    else if (item.Name.Contains("Cream"))
                    {
                        if (item.IsSelect)
                        {
                            if (!tempfood.Customization.OfType<Caters.Model.Customize.Cream>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.CreamFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }

                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.Cream>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.Cream>().First());
                        }
                    }
                    else if (item.Name.Contains("White"))
                    {
                        if (item.IsSelect)
                        {
                            if (!tempfood.Customization.OfType<Caters.Model.Customize.WhiteBread>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.WhiteBreadFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }
                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.WhiteBread>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.WhiteBread>().First());
                        }
                    }
                    else if (item.Name.Contains("Cheese"))
                    {
                        if (item.IsSelect)
                        {

                            if (!tempfood.Customization.OfType<Caters.Model.Customize.CheeseTopping>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.CheeseToppingFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }

                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.CheeseTopping>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.CheeseTopping>().First());
                        }
                    }
                    else if (item.Name.Contains("Sauce"))
                    {
                        if (item.IsSelect)
                        {

                            if (!tempfood.Customization.OfType<Caters.Model.Customize.SauceTopping>().Any())
                            {
                                customizefood = new Model.Factory.CustomizeFactory.SauceToppingFactory();
                                tempfood.Customization.Add(customizefood.GetCutomize());
                            }

                        }
                        else
                        {
                            if (tempfood.Customization.OfType<Caters.Model.Customize.SauceTopping>().Any())
                                tempfood.Customization.Remove(tempfood.Customization.OfType<Caters.Model.Customize.SauceTopping>().First());
                        }
                    }

                }

                Order.Foods = Foods.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        private void AddCustomToOrder(object obj)
        { 

            Order.Foods = Foods.ToList();
            CustomMessage();
        }

        #region Static Data for Choice in UI can be replaced by Database data 
        private void addDummyData(Model.Factory.FoodFactory food)
        {
            PizzaSandwitchCustomOptions.Clear();
            if (food.GetFood() is Model.Pizza.Pizza)
            {
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "BrownBread" });
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "WhiteBread" });
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "CheeseTopping" });
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "SauceBread" });
            }
            else if (food.GetFood() is Model.ColdDrink.ColdDrink)
            {
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "Softy" });
                PizzaSandwitchCustomOptions.Add(new CustomizationOption() { IsSelect = false, Name = "Cream" });
            }


        } 
        #endregion

        #region Add Count in UI and drop down list to user select the choice on selection
        private void AddMethod(object obj)
        {

            try
            {
                Caters.Model.Factory.FoodFactory food = null;
                if ((string)obj == "Mashroom")
                {
                    MashroomsCustomNos = new ObservableCollection<int>();
                    food = new Model.Factory.PizzaFactory.MashroomFactory();
                    Foods.Add(food.GetFood());
                    MashroomCount++;
                    AddDropDown(MashroomCount, obj as string);
                }
                else if ((string)obj == "Panner")
                {
                    PannerCustomNos = new ObservableCollection<int>();
                    food = new Model.Factory.PizzaFactory.PannerFactory();
                    Foods.Add(food.GetFood());
                    PannerCount++;
                    AddDropDown(PannerCount, obj as string);
                }
                else if ((string)obj == "SevenUp")
                {
                    SevenUpCustomNos = new ObservableCollection<int>();
                    food = new Model.Factory.DrinkFactory.SevenUpFactory();
                    Foods.Add(food.GetFood());
                    SevenUpCount++;
                    AddDropDown(SevenUpCount, obj as string);
                }
                addDummyData(food);
            }
            catch (Exception ex)
            {

                throw ex;
            }

       

        } 
        #endregion

        #region Substract the Count as User Clickon "_" button on UI
        private void SubMethod(object obj)
        {
            try
            {
                if ((string)obj == "Mashroom")
                {
                    if (MashroomCount > 0)
                    {
                        MashroomCount--;
                        MashroomsCustomNos.RemoveAt(MashroomsCustomNos.Count - 1);
                        Foods.Remove(Foods.OfType<Caters.Model.Pizza.Mashroom>().First());
                    }
                }
                else if ((string)obj == "Panner")
                {
                    if (PannerCount > 0)
                    {
                        PannerCount--;
                        PannerCustomNos.RemoveAt(PannerCustomNos.Count - 1);
                        Foods.Remove(Foods.OfType<Caters.Model.Pizza.PannerPizza>().First());
                    }
                }
                else if ((string)obj == "SevenUp")
                {
                    if (SevenUpCount > 0)
                    {
                        SevenUpCount--;
                        SevenUpCustomNos.RemoveAt(SevenUpCustomNos.Count - 1);
                        Foods.Remove(Foods.OfType<Caters.Model.ColdDrink.SevenUp>().First());
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
          
        } 
        #endregion

        #region Drop down count for customie the selected Index
        private void AddDropDown(int MashroomCount, string param)
        {
            if (param == "Mashroom")
            {
                MashroomsCustomNos.Clear();
                for (int i = 1; i <= _MashroomCount; i++)
                {
                    MashroomsCustomNos.Add(i);
                }
            }
            else if (param == "Panner")
            {
                PannerCustomNos.Clear();
                for (int i = 1; i <= _PannerCount; i++)
                {
                    PannerCustomNos.Add(i);
                }
            }
            else if (param == "SevenUp")
            {
                SevenUpCustomNos.Clear();
                for (int i = 1; i <= _SevenUpCount; i++)
                {
                    SevenUpCustomNos.Add(i);
                }
            }


           
        } 
        #endregion



        #region INPC implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        } 
        #endregion
    }

    /// <summary>
    /// Custom class to handle the selection of choice fromUI
    /// </summary>
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
