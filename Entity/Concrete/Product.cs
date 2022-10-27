﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Guid SupplierId { get; set; }

    [DisplayName("Product Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
    [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 50")]
    public string Name { get; set; }

    [DisplayName("Product Price")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a price")]
    public decimal Price { get; set; }

    [DisplayName("Product Image")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an image path")]
    public string ImagePath { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }

    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Supplier> Suppliers { get; set; }

    public Product()
    {
    }

    public Product(Guid id,
        Guid categoryId,
        Guid supplierId,
        string name,
        decimal price,
        string imagePath,
        IFormFile? imageFile) : this()
    {
        Id = id;
        CategoryId = categoryId;
        SupplierId = supplierId;
        Name = name;
        Price = price;
        ImagePath = imagePath;
        ImageFile = imageFile;  
    }
}