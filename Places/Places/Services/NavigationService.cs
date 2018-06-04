namespace Places.Services
{
    using Views;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class NavigationService
    {
        public void setMainPage(string pageName)
        {
            switch (pageName)
            {
                case "LoginView":
                    Application.Current.MainPage = new NavigationPage(new LoginView());
                    break;

                case "MasterView":
                    Application.Current.MainPage = new NavigationPage(new MasterView());
                    break;
            }
        }

        public async Task NavigateOnMaster(string pageName)
        {

            App.Master.IsPresented = false;

            switch (pageName)
            {
                case "CategoriesView":
                    await App.Navigator.PushAsync(
                   new CategoriesView());
                    break;

                case "PlacesView":
                    await App.Navigator.PushAsync(
                   new PlacesView());
                    break;

                case "NewCategoryView":
                    await App.Navigator.PushAsync(
                   new NewCategoryView());
                    break;

                case "EditCategoryVie":
                    await App.Navigator.PushAsync(
                   new EditCategoryView());
                    break;

                case "NewPlaceView":
                    await App.Navigator.PushAsync(
                   new NewPlaceView());
                    break;

                case "EditPlaceView":
                    await App.Navigator.PushAsync(
                   new EditPlaceView());
                    break;

             
            }
            
        }

        public async Task NavigateOnLogin(string pageName)
        {
            switch (pageName)
            {
                case "NewCustomerView":
                    await Application.Current.MainPage.Navigation.PushAsync(
                   new NewCustomerView());
                    break;

                //case "CaloriesView":
                    //await Application.Current.MainPage.Navigation.PushAsync(
                   //new CaloriesView());
                    //break;
            }

        }

        public async Task BackOnMaster()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task BackOnLogin()
        {
            await App.Navigator.PopAsync();
        }
    }
}
