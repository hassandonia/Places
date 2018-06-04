namespace Places.Models

{
    using GalaSoft.MvvmLight.Command;
    using Places.Services;
    using System.Windows.Input;
    using ViewModels;
    public class Menu
    {

        #region Services
        NavigationService navigationService;
        #endregion
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion


        #region Constructors
        public Menu()
        {
           
            navigationService = new NavigationService();
        }
        #endregion
        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        void Navigate()
        {
            switch (PageName)
            {
                case "LoginView":
                    var mainViewModel = MainViewModel.GetInstance();

                    mainViewModel.Login = new LoginViewModel();
                    navigationService.setMainPage(PageName);
                    break;

            }
        }
        #endregion

    }
}
