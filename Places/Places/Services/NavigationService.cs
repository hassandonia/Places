namespace Places.Services
{
    using Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using System;

    public class NavigationService
    {
        public async Task Navigate(string pageName)
        {
            switch (pageName)
            {
                case "CategoriesView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new CategoriesView());
                    break;

                case "PlacesView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new PlacesView());
                    break;

                case "NewCategoryView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new NewCategoryView());
                    break;
            }
            
        }

        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
