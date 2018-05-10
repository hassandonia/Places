namespace Places.Services
{
    using Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;

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

                case "EditCategoryVie":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new EditCategoryView());
                    break;

                case "NewPlaceView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new NewPlaceView());
                    break;

                case "EditPlaceView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new EditPlaceView());
                    break;

                case "NewCustomerView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new NewCustomerView());
                    break;

                case "CaloriesView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new CaloriesView());
                    break;
            }
            
        }

        public async Task Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
