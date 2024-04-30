using CleanArch.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();

        Task<CategoryDTO> getById(int? id);

        Task add(CategoryDTO categoryDto);

        Task Update(CategoryDTO categoryDTO);

        Task Remove(int? id);

    }
}
