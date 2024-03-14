using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Weather_Application.Model;
using Weather_Application.ViewModel.Commands;
using Weather_Application.ViewModel.Helpers;

namespace Weather_Application.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        //view gözükecek hertürlü bilgiyi tutar (helper gibi bilgiyi biyerden çekmez. bilgiyi helper verir zaten)
        //VMs change anlamak için INotifyPropertyChanged inherit eder
        /*query, citys, condition bilgilerini tutup display etcem*
          city birden fazla olcak ama liste yerine collection kullancam çünkü city class???*/
        
        private string query;
        public string Query
        {
            get { return query; }
            set 
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private ObservableCollection<City> locations;
        public ObservableCollection<City> Locations 
        {
            get { return locations; }
            set
            {
                locations = value;
                OnPropertyChanged("Locations");
            }
        }

        private Conditions conditions;

        public Conditions Conditions
        {
            get { return conditions; }
            set
            {
                conditions = value;
                OnPropertyChanged("Conditions");
            }
        }

        private City city;

        public City City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged("City");
                GetSelectedConditions(value);

            }
        }

        public SearchCityCommand SearchCityCommand { get; set; }


        //bu baya fix
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public WeatherVM()
        {

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                City = new City()
                {
                    LocalizedName = "New York"
                };
                Conditions = new Conditions
                {
                    WeatherText = "Partly cloudy",
                    HasPrecipitation = true,
                    Temperature = new Temperature
                    {
                        Metric = new Units
                        {
                            Value = "21"
                        }
                    }
                };
            }

            SearchCityCommand = new SearchCityCommand(this);
            Locations = new ObservableCollection<City>();

        }

        private async void GetSelectedConditions(City selectedCity)
        {
            if(selectedCity != null) 
            { 
                Conditions = await AccuWeatherApiHelper.GetConditions(selectedCity.Key);
            }
        }
        public async void MakeQuery()
        {
            var locations = await AccuWeatherApiHelper.GetLocations(Query);

            Locations.Clear();
            foreach (var location in locations)
            {
                Locations.Add(location);
            }
        }
    }
}
