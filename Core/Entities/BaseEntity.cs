﻿namespace WebNetSample.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int id) : this()
        {
            Id = id;
        }
    }
}