﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities;

namespace ShoeShop.Dtos
{
    public class CategoryDto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen isim giriniz!")]
        [MinLength(3, ErrorMessage = "En az 3 karakter uzunluğunda olmalıdır!")]
        [Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
