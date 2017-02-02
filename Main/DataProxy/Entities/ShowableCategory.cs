﻿namespace DataProxy.Entities
{
    using System;
    using System.ComponentModel;
    using DatabaseConnector;

    public class ShowableCategory 
    {
        public ShowableCategory(Category cat)
        {
            Slug = cat.slug;
            Name = cat.category_name;
            Overriding = cat.Category1 != null ? cat.Category1.category_name : "";
            Id = cat.id;
        }
        public ShowableCategory() { }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Overriding { get; set; }
        public int Id;
    }
}
