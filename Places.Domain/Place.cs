using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Domain
{
    public class Place
    {
        [Key]
        public int PlaceId { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Index("Place_Description_Index", IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString ="{0:C2}" , ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "IsActive?.")]
        public bool IsActive { get; set; }

        [Display(Name = "Last contract")]
        [DataType(DataType.Date)]
        public DateTime LastPurchase { get; set; }

        public string Image { get; set; }

        public double Stock { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

    }
}
