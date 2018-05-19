namespace Places.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class MainViewModel
    {

        #region Services

        NavigationService navigationService;
        #endregion

        #region Proerties

        public ObservableCollection<Menu> MyMenu
        {
            get;
            set;
        }


        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        public PlacesViewModel Places
        {
            get;
            set;
        }

        public NewCategoryViewModel NewCategory
        {
            get;set;
        }

        public EditCategoryViewModel EditCategory
        {
            get;
            set;    
        }

        public EditPlaceViewModel EditPlace
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;    
        }

        public NewCustomerViewModel NewCustomer
        {
            get;set;
        }
        
        #endregion



        #region Constructors
        public MainViewModel()
        {
            instance = this;

            navigationService = new NavigationService();

            Login = new LoginViewModel();
            LoadMenu();
        }
        
        #endregion

        #region Sigleton

        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion


        #region Methods

        private void LoadMenu()
        {
            MyMenu = new ObservableCollection<Menu>();
            MyMenu.Add(new Menu
            {
                Icon = "ic_settings.png",
                PageName = "My Profile",
                Title = "Profile"
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_map.png",
                PageName = "Places Map",
                Title = "Maps"
            });

            MyMenu.Add(new Menu
            {
                Icon = "ic_exit_to_app.png",
                PageName = "LoginView",
                Title = "Close"
            });
        }

        #endregion

        #region Commands

        public ICommand NewPlaceCommand
        {
            get
            {
                return new RelayCommand(GoNewPlace);
            }
        }

        async void GoNewPlace()
        {
            NewPlace = new NewPlaceViewModel();
            await navigationService.NavigateOnMaster("NewPlaceView");
        }

        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(GoNewCategory);
            }
        }

        public NewPlaceViewModel NewPlace { get; private set; }

        async void GoNewCategory()
        {
            NewCategory = new NewCategoryViewModel();
            await navigationService.NavigateOnMaster("NewCategoryView");
        }

        #endregion

    }
}
