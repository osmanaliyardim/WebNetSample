using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos
{
    public record CategoryDetailDto : BaseDto
    {
        public CategoryDetailDto(
            string name,
            string imagePath,
            IFormFile? imageFile)
        {
            Name = name;
            ImagePath = imagePath;
            ImageFile = imageFile;
        }

        public string Name { get; }

        public string ImagePath { get; }

        public IFormFile? ImageFile { get; }
    }
}