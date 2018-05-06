namespace Places.API.Models
{
    using System;

    public class PlaceResponse
    {
        public int PlaceId { get; set; }
        
        public string Description { get; set; }
        
        public decimal Price { get; set; }
       
        public bool IsActive { get; set; }
        
        public DateTime LastPurchase { get; set; }

        public string Image { get; set; }

        public double Stock { get; set; }

        public string Remarks { get; set; }
    }
}