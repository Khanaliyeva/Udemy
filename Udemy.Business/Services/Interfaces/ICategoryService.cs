using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Core.Entities;

namespace Udemy.Business.Services.Interfaces
{
    public interface ICategoryservice
    {
        Task<ICollection<CategoryGetDto>> GetAllAsync(
            Expression<Func<Category, bool>>? expression = null,
            Expression<Func<Category, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            );

        Task<CategoryGetDto> GetById(int id);
        Task<Category> CreateAsync(CategoryCreateDto createDto);
        Task<Category> UpdateAsync(CategoryUpdateDtos entity);
        Task<Category> DeleteAsync(int Id);

    }
}
