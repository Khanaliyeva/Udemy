using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Core.Entities;

namespace Udemy.Business.Services.Interfaces
{
    public interface ICategoryservice
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<bool> CreateAsync(CategoryCreateDto createDto);

    }
}
