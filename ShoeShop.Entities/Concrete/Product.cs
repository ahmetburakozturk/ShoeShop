﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeShop.Entities.Abstract;
using ShoeShop.Entities.Concrete;

namespace ShoeShop.Entities
{
    public class Product:IEntity
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public int ColorID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public int GenderID { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public double Size { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public double? Discount { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [Display(Name = "Marka")]
        public string? Material { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
    }
}
