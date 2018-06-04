namespace Places.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Windows.Input;
    using Services;
    using Xamarin.Forms;
    using Views;
    using System;

    public class LoginViewModel : INotifyPropertyChanged
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

        string _email;
        string _password;
        bool _isToggled;
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
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    PropertyChanged?.Invoke(this,
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
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(IsRunning)));
                }
            }
        }

        public bool IsToggled
        {
            get
            {
                return _isToggled;
            }
            set
            {
                if (_isToggled != value)
                {
                    _isToggled = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(IsToggled)));
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Password)));
                }
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }

        #endregion

        #region Constructors
        public LoginViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            navigationService = new NavigationService();    

            //Email = "hassanbasha@gmail.com";
            //Password = "123456";

            IsEnabled = true;
            IsToggled = true;
            IsRunning = false;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        async void Login()
        {
            if (string.IsNullOrEmpty(Email))
            {
                IsRunning = true;
                await dialogService.ShowMessage(
                "Error",
                "You must enter valid email.");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                IsRunning = true;
                await dialogService.ShowMessage(
                "Error",
                "You must enter valid password.");
                return;
            }
            IsRunning = true;
            IsEnabled = false;

            var connection = await apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                IsRunning = true;
                IsEnabled = true;
                await dialogService.ShowMessage("Error", connection.Message);
                return;
            }
            var response = await apiService.GetToken(
                "https://placesapii.azurewebsites.net",
            Email,
            Password);

            if (response == null)
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error",
                "The service is not available, please try again later.");
                Password = null;
                return;
            }

            if (string.IsNullOrEmpty(response.AccessToken))
            {
                IsRunning = false;
                IsEnabled = true;
                await dialogService.ShowMessage("Error",
                response.ErrorDescription);
                Password = null;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = response;
            mainViewModel.Categories = new CategoriesViewModel();
            navigationService.setMainPage("MasterView");


            Email = null;
            Password = null;

            IsRunning = false;
            IsEnabled = true;
        }
        public ICommand LoginWithFacebookCommand
        {
            get
            {
                return new RelayCommand(Calories);
            }
        }

        async void Calories()
        {
            

            await Application.Current.MainPage.Navigation.PushAsync(
                    new CaloriesView());
        }

     



        public ICommand RegisterNewUserCommand
        {
            get {
                return new RelayCommand(RegisterNewUser);
                    }
        }

        async void RegisterNewUser()
        {
            MainViewModel.GetInstance().NewCustomer = new NewCustomerViewModel();
            await navigationService.NavigateOnLogin("NewCustomerView");
        }
        #endregion
    }
    }

