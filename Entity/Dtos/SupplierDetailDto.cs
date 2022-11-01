using System;
using WebNetSample.Core.Entities;

namespace WebNetSample.Entity.Dtos
{
    public record SupplierDetailDto : BaseDto
    {
        public SupplierDetailDto(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}