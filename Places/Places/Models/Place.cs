﻿namespace Places.Models
{
    using System;

    public class Place
    {
        public int PlaceId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastPurchase { get; set; }

        public double Stock { get; set; }

        public string Remarks { get; set; }

        public string ImageFullPath
        {
            get
            {

                if (string.IsNullOrEmpty(Image))
                {
                    return "ic_add_circle";
                }
                return string.Format("http://localhost:50552/{0}",
                    Image.Substring(1));
            }
          
        }
    }
}
