using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Concrete;

public class Category : BaseEntity
{
    [DisplayName("Category Name")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a name")]
    [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Length must be between 3 to 50")]
    public string Name { get; set; }

    [DisplayName("Category Image")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an image path")]
    public string ImagePath { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; }

    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
    }

    public Category(
        Guid id, 
        string name, 
        string imagePath) : this()
    {
        Id = id;
        Name = name;
        ImagePath = imagePath;
    }
}