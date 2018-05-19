namespace Places.Models
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Windows.Input;
    using ViewModels;
    using Services;
    using System;

    public class Category
    {

        #region Services

        NavigationService navigationService;
        DialogService dialogService;
        #endregion

        #region Properties
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<Place> Places { get; set; }
        #endregion
        
        #region Constructors

        public Category()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
        }
        #endregion

        #region Methods

        public override int GetHashCode()
        {
            return CategoryId;
        }

        #endregion

        #region Commands

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(Delete);
            }


        }

        async void Delete()
        {
            var response = await dialogService.ShowConfirm(
                "Confirm",
                "Are You Sure to delete this record?");

            if (!response)
            {
                return;
            }
            await CategoriesViewModel.GetInstance().DeleteCategory(this);
        }


        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(Edit);
            }


        }
        
        async void Edit()
        {
            MainViewModel.GetInstance().EditCategory =
                new EditCategoryViewModel(this);
            await navigationService.NavigateOnMaster("EditCategoryView");
        }

        public ICommand SelectCategoryCommand
        {
            get
            {

                return new RelayCommand(SelectCategory);
            }
        }

        async void SelectCategory()
        {

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Category = this;
            mainViewModel.Places = new PlacesViewModel(Places);
            await navigationService.NavigateOnMaster("PlacesView");

        }
        #endregion
    }
}
