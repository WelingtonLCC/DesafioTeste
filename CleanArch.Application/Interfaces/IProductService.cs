using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();

        Task<ProductDTO> GetByID(int? id);

        /*Task<ProductDTO> GetProductCategory(int? id);*/

        Task Add(ProductDTO productDTO);

        Task Update(ProductDTO productDTO);

        Task Delete(int? id);
    }
}
