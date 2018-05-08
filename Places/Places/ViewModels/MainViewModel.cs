namespace Places.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;
    using System.Windows.Input;

    public class MainViewModel
    {

        #region Services

        NavigationService navigationService;
        #endregion

        #region Proerties

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

        public Category Category
        {
            get;
            set;    
        }

        #endregion



        #region Constructors
        public MainViewModel()
        {
            instance = this;

            navigationService = new NavigationService();

            Login = new LoginViewModel();
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


            #region Commands

        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(GoNewCategory);
            }
        }

        async void GoNewCategory()
        {
            NewCategory = new NewCategoryViewModel();
            await navigationService.Navigate("NewCategoryView");
        }

        #endregion

    }
}
