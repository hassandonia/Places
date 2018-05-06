namespace Places.Backend.Models
{
    using Domain;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [NotMapped]
    public class PlaceView : Place
    {
        
        public HttpPostedFileBase ImageFile { get; set; }
    }
}