using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;

namespace Udemy.Business.DTOs.CategoryDtos
{
    public class CategoryGetDto:BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public int? ParentCategoryId { get; set; }
        public CategoryGetDto ParentCategory { get; set; }
        public ICollection<CategoryGetDto> ChildenCategories { get; set; }

    }




    public class CategoryGetDtoValidation : AbstractValidator<CategoryGetDto>
    {
        public CategoryGetDtoValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Bos olmaz");
        }
    }
}
