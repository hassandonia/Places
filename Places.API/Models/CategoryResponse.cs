namespace Places.API.Models
{
    using System.Collections.Generic;

    public class CategoryResponse
    {
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<PlaceResponse> Places { get;
            set;
        }
    }
}