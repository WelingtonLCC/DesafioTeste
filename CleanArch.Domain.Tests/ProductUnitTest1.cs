using CleanArch.Domain.Entities;
using FluentAssertions;
using System.Security.AccessControl;
using System.Xml.Serialization;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameter_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image");

            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Po", "Product Description", 9.99m, 99, "product image");

            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 caracteres");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, "product image oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo lllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll llllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllllll llllllllllllllllllllllllllllllllllll");

            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 caracters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, null);

            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptylImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, 99, "");

            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValie_NoDomainException()
        {
            Action action = () => new Product(1, "Prodd", "Product Description", -9.99m, 99, "");

            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "product", "Product Description", 9.99m, value, "Product image");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

    }
}
