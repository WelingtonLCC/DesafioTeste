using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, Product>
    {
        private readonly IProductRepository _repository;

        public ProductDeleteCommandHandler(IProductRepository repository)
        {
            _repository = repository?? 
                throw new ArgumentNullException(nameof(repository));
        }
        public async Task<Product> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not ne found");
            }
            else
            {
                var result = await _repository.DeleteAsync(product);

                return result;
            }
        }
    }
}
