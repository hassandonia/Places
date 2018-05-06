﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="The field {0} is required")]
        [MaxLength(50,ErrorMessage = "The field {0} only can contain {1} characters length.")]
        [Index("Category_Description_Index" , IsUnique = true)]
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Place> Places { get; set; }

    }
}
