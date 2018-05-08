using GalaSoft.MvvmLight.Command;
using Places.Models;
using Places.Services;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Places.ViewModels
{
    public class NewCategoryViewModel : INotifyPropertyChanged
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
                if(_isRunning != value){
                    _isRunning = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public string Description
        {
            get;
            set;
        }
        #endregion

        #region Constructors

        public NewCategoryViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();

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
                    "You must enter a category description");
                return;
            }
            IsEnabled = false;
            IsRunning = true;

            var connection = await apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error",
                    connection.Message);
                return;
            }
            var category = new Category {

                Description = Description,
            };
            var mainViewModel = MainViewModel.GetInstance();
            var response = await apiService.Post(
                "",
                "/api",
                "/Categories",
                mainViewModel.Token.TokenType,
                mainViewModel.Token.AccessToken,
                category);
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage(
                    "Error",
                    response.Message);
                return;
            }

            category = (Category)response.Result;
            var categoriesViewModel = CategoriesViewModel.GetInstance();
            categoriesViewModel.AddCategory(category);

            await navigationService.Back();
            IsEnabled = true;
            IsRunning = false;
        }
        #endregion
    }
}
