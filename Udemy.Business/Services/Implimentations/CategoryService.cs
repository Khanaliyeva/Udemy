using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Business.Exceptions.Category;
using Udemy.Business.Services.Interfaces;
using Udemy.Core.Entities;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.Business.Services.Implimentations
{
    public class CategoryService : ICategoryservice
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CreateAsync(CategoryCreateDto createDto)
        {

            if (createDto == null) throw new categoryNullException();
            Category category = new Category()
            {
                Title = createDto.Title,
                ParentId = createDto.ParentCategoryId
            };
            await _repo.CreateAsync(category);
            int result = await _repo.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories=await _repo.GetAllAsync();
            return await categories.ToListAsync();
        }
    }
}
