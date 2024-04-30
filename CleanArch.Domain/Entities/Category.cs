using CleanArch.Domain.Validation;
using System.Collections.Generic;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get;private set; }

        public Category(string name)
        {
            this.ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id Value");
            this.Id = id;
            this.ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.NAme is required");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 caracteres");

            this.Name = name;
        }
    }
}
