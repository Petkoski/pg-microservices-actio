﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activities.Domain.Models
{
    public class Category
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }

        protected Category()
        {

        }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            Name = name.ToLowerInvariant();
        }
    }
}
