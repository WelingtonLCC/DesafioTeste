using CleanArch.Domain.Validation;
using System.Collections;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace CleanArch.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }    
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public decimal Stock { get; private set;}
        public string Image { get; private set;}

        public Product(string name, string description, decimal price, decimal stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public Product(int id,string name, string description, decimal price, decimal stock, string image)
        {
                DomainExceptionValidation.When(id < 0, "Invalid Id value");
                this.Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(string name, string description, decimal price, decimal stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description,decimal price, decimal stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.NAme is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid name.NAme is required");

            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 caracteres");

            DomainExceptionValidation.When(price < 0, "Invalid price value");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 caracters");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
