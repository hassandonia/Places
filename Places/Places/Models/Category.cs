namespace Places.Models
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System.Collections.Generic;
    using System.Windows.Input;
    using ViewModels;
    using Services;

    public class Category
    {

        #region Services

        NavigationService navigationService;
        #endregion

        #region Properties
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<Place> Places { get; set; }
        #endregion
        

        #region Commands

        public ICommand SelectCategoryCommand {
            get
            {

                return new RelayCommand(SelectCategory);
            } 
        }

        async void SelectCategory()
        {

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Places = new PlacesViewModel(Places);
            await navigationService.Navigate("PlacesView");
         
        }
        #endregion

        #region Constructors

        public Category()
        {
            navigationService = new NavigationService();
        }
        #endregion

    }
}
