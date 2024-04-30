using CleanArch.Domain.Entities;
using FluentAssertions;
using System.Security.AccessControl;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {    

        // Teste Unitario para utilização de cateogry 
        // Não pode ter exception
        [Fact(DisplayName = "CreateCategory With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"Category Name");
            action.Should().NotThrow<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithValidParameters_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid id Value");
        }

        [Fact]
        public void CreateCategory_WithValidParameters_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 caracteres");
        }


        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.NAme is required");
        }



        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CleanArch.Domain.Validation.DomainExceptionValidation>();
        }
    }
}