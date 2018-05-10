using Places.Domain;

namespace Places.API.Models
{
    public class PlaceRequest : Place
    {
        public byte[] ImageArray { get; set; }
    }
}