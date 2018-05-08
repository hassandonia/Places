using GalaSoft.MvvmLight.Command;
using Places.Models;
using Places.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Places.ViewModels
{
    public class NewPlaceViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Services
        ApiService apiService;
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Attributes
        bool _isRunning;
        bool _isEnabled;
        #endregion

        #region Properties

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                if(_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }

        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                if (_isRunning != value)
                {
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public string Description { get; set; }

        public string Price { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastPurchase { get; set; }

        public string Stock { get; set; }

        public string Remarks { get; set; }

        public string Image { get; set; }
        #endregion

        #region Constructors
        public NewPlaceViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();

            Image = "ic_add_circle";
            IsActive = true;
            LastPurchase = DateTime.Today;

            IsEnabled = true;
        }
        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        async void Save()
        {
            if (string.IsNullOrEmpty(Description))
            {
                await dialogService.ShowMessage("Error",
                    "You must enter a place description");
                return;
            }
            if (string.IsNullOrEmpty(Price))
            {
                await dialogService.ShowMessage("Error",
                    "You must enter a place description");
                return;
            }

            var price = decimal.Parse(Price);
            if(price < 0)
            {
                await dialogService.ShowMessage("Error",
                    "The price must be a value greater or equals than zero.");
                return;
            }
            var stock = double.Parse(Stock);
            if(stock < 0)
            {
                await dialogService.ShowMessage("Error",
                    "The stock must be a value greater or equals than zero");
                return;
            }
            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }
            var mainViewModel = MainViewModel.GetInstance();

            var place = new Place
            {
                CategoryId = mainViewModel.Category.CategoryId,
                Description = Description,
                IsActive = IsActive,
                LastPurchase = LastPurchase,
                Price = price,
                Remarks = Remarks,
                Stock = stock,
            };
            var response = await apiService.Post(
                "",
                "/api",
                "Places",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken,
                place);
        }
        #endregion

    }
}
