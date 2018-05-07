namespace Places.ViewModels
{
    using Places.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    public class PlacesViewModel : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        List<Place> places;
        ObservableCollection<Place> _places;
        #endregion

        #region Properties

        public ObservableCollection<Place> Places
        {

            get
            {
                return _places;
            }
            set
            {
                if (_places != value)
                {
                    _places = value;
                    PropertyChanged?.Invoke(
                        this,
                        new PropertyChangedEventArgs(
                            nameof(Places)));
                }
            }
        }

        #endregion

        #region Constructors
        public PlacesViewModel(List<Place> places)
        {
            this.places = places;
            Places = new ObservableCollection<Place>(places.OrderBy(p => p.Description));
        }

        
        #endregion

    }
}
