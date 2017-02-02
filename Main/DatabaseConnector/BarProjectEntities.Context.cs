﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseConnector
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BarProjectEntities : DbContext
    {
        public BarProjectEntities()
            : base("name=BarProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<EmployePermission> EmployePermissions { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsSold> ProductsSolds { get; set; }
        public virtual DbSet<ProductsStored> ProductsStoreds { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int addTax(string tax_name, Nullable<double> tax_value)
        {
            var tax_nameParameter = tax_name != null ?
                new ObjectParameter("tax_name", tax_name) :
                new ObjectParameter("tax_name", typeof(string));
    
            var tax_valueParameter = tax_value.HasValue ?
                new ObjectParameter("tax_value", tax_value) :
                new ObjectParameter("tax_value", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addTax", tax_nameParameter, tax_valueParameter);
        }
    
        public virtual int addUnit(string unit_name, Nullable<double> convert_factor, Nullable<int> unit_type)
        {
            var unit_nameParameter = unit_name != null ?
                new ObjectParameter("unit_name", unit_name) :
                new ObjectParameter("unit_name", typeof(string));
    
            var convert_factorParameter = convert_factor.HasValue ?
                new ObjectParameter("convert_factor", convert_factor) :
                new ObjectParameter("convert_factor", typeof(double));
    
            var unit_typeParameter = unit_type.HasValue ?
                new ObjectParameter("unit_type", unit_type) :
                new ObjectParameter("unit_type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addUnit", unit_nameParameter, convert_factorParameter, unit_typeParameter);
        }
    
        public virtual int addUser(string password, string username, string name, string surname, Nullable<byte> permission)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var surnameParameter = surname != null ?
                new ObjectParameter("surname", surname) :
                new ObjectParameter("surname", typeof(string));
    
            var permissionParameter = permission.HasValue ?
                new ObjectParameter("permission", permission) :
                new ObjectParameter("permission", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addUser", passwordParameter, usernameParameter, nameParameter, surnameParameter, permissionParameter);
        }
    
        public virtual int deleteTax(string tax_name)
        {
            var tax_nameParameter = tax_name != null ?
                new ObjectParameter("tax_name", tax_name) :
                new ObjectParameter("tax_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteTax", tax_nameParameter);
        } 

        public virtual int removeUnit(string unit_name)
        {
            var unit_nameParameter = unit_name != null ?
                new ObjectParameter("unit_name", unit_name) :
                new ObjectParameter("unit_name", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeUnit", unit_nameParameter);
        }
        public virtual int getRandom(Nullable<int> seed, ObjectParameter random)
        {
            var seedParameter = seed.HasValue ?
                new ObjectParameter("Seed", seed) :
                new ObjectParameter("Seed", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("getRandom", seedParameter, random);
        }
    
        public virtual int getSalt(ObjectParameter salt)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("getSalt", salt);
        }
    
        public virtual int updateTax(Nullable<int> id, string new_tax_name, Nullable<double> new_tax_value)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var new_tax_nameParameter = new_tax_name != null ?
                new ObjectParameter("new_tax_name", new_tax_name) :
                new ObjectParameter("new_tax_name", typeof(string));
    
            var new_tax_valueParameter = new_tax_value.HasValue ?
                new ObjectParameter("new_tax_value", new_tax_value) :
                new ObjectParameter("new_tax_value", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateTax", idParameter, new_tax_nameParameter, new_tax_valueParameter);
        }
    
        public virtual int updateUnit(Nullable<int> id, string new_unit_name, Nullable<double> new_convert_factor, Nullable<int> new_unit_type)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var new_unit_nameParameter = new_unit_name != null ?
                new ObjectParameter("new_unit_name", new_unit_name) :
                new ObjectParameter("new_unit_name", typeof(string));
    
            var new_convert_factorParameter = new_convert_factor.HasValue ?
                new ObjectParameter("new_convert_factor", new_convert_factor) :
                new ObjectParameter("new_convert_factor", typeof(double));
    
            var new_unit_typeParameter = new_unit_type.HasValue ?
                new ObjectParameter("new_unit_type", new_unit_type) :
                new ObjectParameter("new_unit_type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateUnit", idParameter, new_unit_nameParameter, new_convert_factorParameter, new_unit_typeParameter);
        }
    
        public virtual int userExists(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("login", login) :
                new ObjectParameter("login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userExists", loginParameter);
        }
    
        public virtual int checkCredentials(string username, string password, ObjectParameter tmp_credentials)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("checkCredentials", usernameParameter, passwordParameter, tmp_credentials);
        }
    
        public virtual int addCategory(string category_name, string slug, Nullable<int> overriding_category)
        {
            var category_nameParameter = category_name != null ?
                new ObjectParameter("category_name", category_name) :
                new ObjectParameter("category_name", typeof(string));
    
            var slugParameter = slug != null ?
                new ObjectParameter("slug", slug) :
                new ObjectParameter("slug", typeof(string));
    
            var overriding_categoryParameter = overriding_category.HasValue ?
                new ObjectParameter("overriding_category", overriding_category) :
                new ObjectParameter("overriding_category", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addCategory", category_nameParameter, slugParameter, overriding_categoryParameter);
        }
    
        public virtual int addIngredient(Nullable<int> receipt_id, Nullable<int> ingredient_id, Nullable<double> quantity)
        {
            var receipt_idParameter = receipt_id.HasValue ?
                new ObjectParameter("receipt_id", receipt_id) :
                new ObjectParameter("receipt_id", typeof(int));
    
            var ingredient_idParameter = ingredient_id.HasValue ?
                new ObjectParameter("ingredient_id", ingredient_id) :
                new ObjectParameter("ingredient_id", typeof(int));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("quantity", quantity) :
                new ObjectParameter("quantity", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addIngredient", receipt_idParameter, ingredient_idParameter, quantityParameter);
        }
    
        public virtual int addReceipt(string description)
        {
            var descriptionParameter = description != null ?
                new ObjectParameter("description", description) :
                new ObjectParameter("description", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addReceipt", descriptionParameter);
        }
    
        public virtual int removeCategory(Nullable<int> category_id)
        {
            var category_idParameter = category_id.HasValue ?
                new ObjectParameter("category_id", category_id) :
                new ObjectParameter("category_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeCategory", category_idParameter);
        }
    
        public virtual int addProduct(Nullable<int> category_id, Nullable<int> unit_id, Nullable<int> tax_id, string name)
        {
            var category_idParameter = category_id.HasValue ?
                new ObjectParameter("category_id", category_id) :
                new ObjectParameter("category_id", typeof(int));
    
            var unit_idParameter = unit_id.HasValue ?
                new ObjectParameter("unit_id", unit_id) :
                new ObjectParameter("unit_id", typeof(int));
    
            var tax_idParameter = tax_id.HasValue ?
                new ObjectParameter("tax_id", tax_id) :
                new ObjectParameter("tax_id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addProduct", category_idParameter, unit_idParameter, tax_idParameter, nameParameter);
        }
    
        public virtual int addSoldProduct(Nullable<int> product_id, Nullable<int> receipt_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            var receipt_idParameter = receipt_id.HasValue ?
                new ObjectParameter("receipt_id", receipt_id) :
                new ObjectParameter("receipt_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addSoldProduct", product_idParameter, receipt_idParameter);
        }
    
        public virtual int addStoredProduct(Nullable<int> product_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addStoredProduct", product_idParameter);
        }
    
        public virtual int removeProduct(Nullable<int> product_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeProduct", product_idParameter);
        }
    
        public virtual int removeSoldProduct(Nullable<int> product_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeSoldProduct", product_idParameter);
        }
    
        public virtual int removeStoredProduct(Nullable<int> product_id)
        {
            var product_idParameter = product_id.HasValue ?
                new ObjectParameter("product_id", product_id) :
                new ObjectParameter("product_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeStoredProduct", product_idParameter);
        }
    
        public virtual int updatePrice(Nullable<int> priduct_id, Nullable<double> new_price)
        {
            var priduct_idParameter = priduct_id.HasValue ?
                new ObjectParameter("priduct_id", priduct_id) :
                new ObjectParameter("priduct_id", typeof(int));
    
            var new_priceParameter = new_price.HasValue ?
                new ObjectParameter("new_price", new_price) :
                new ObjectParameter("new_price", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updatePrice", priduct_idParameter, new_priceParameter);
        }
    
        public virtual int removeTax(string tax_name)
        {
            var tax_nameParameter = tax_name != null ?
                new ObjectParameter("tax_name", tax_name) :
                new ObjectParameter("tax_name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("removeTax", tax_nameParameter);
        }
    
    }
}
