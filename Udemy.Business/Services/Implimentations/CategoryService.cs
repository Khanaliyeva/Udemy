using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.CategoryDtos;
using Udemy.Business.Exceptions.Category;
using Udemy.Business.Exceptions.Common;
using Udemy.Business.Services.Interfaces;
using Udemy.Core.Entities;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.Business.Services.Implimentations
{
    public class CategoryService : ICategoryservice
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;


        public CategoryService(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Category> CreateAsync(CategoryCreateDto createDto)
        {

            if (createDto == null) throw new categoryNullException();
            Category category = new Category()
            {
                Title = createDto.Title,
                ParentCategoryId = createDto.ParentCategoryId
            };
            var result = await _repo.CreateAsync(category);
            await _repo.SaveChangesAsync();

            return result;
        }


        public async Task<ICollection<CategoryGetDto>> GetAllAsync(Expression<Func<Category, bool>>? expression = null, Expression<Func<Category, object>>? expressionOrder = null, bool isDescending = false, params string[] includes)
        {
            var result = await _repo.GetAllAsync();

            return _mapper.Map<ICollection<CategoryGetDto>>(result.Include(x => x.Children));
        }


        public async Task<CategoryGetDto> GetById(int id)
        {
            if (id <= 0) throw new NegativeIdException();

            var result = await _repo.GetById(id);
            return _mapper.Map<CategoryGetDto>(result);
        }


        public async Task<Category> UpdateAsync(CategoryUpdateDtos entity)
        {

            Category oldCategory = await _repo.GetById(entity.Id);

            oldCategory.Title = entity.Title;
            oldCategory.ParentCategoryId = entity.ParentCategoryId;
            oldCategory.CreateAt = DateTime.Now;
            oldCategory.UpdateAt = oldCategory.CreateAt;

            var result = await _repo.UpdateAsync(oldCategory);
            await _repo.SaveChangesAsync();

            return result;
        }
        public async Task<Category> DeleteAsync(int Id)
        {
            if (Id <= 0 || Id == null) throw new NegativeIdException();

            Category oldCategory = await _repo.GetById(Id);

           

            await _repo.DeleteAsync(oldCategory);
            await _repo.SaveChangesAsync();

            return oldCategory;
        }
    }
}
