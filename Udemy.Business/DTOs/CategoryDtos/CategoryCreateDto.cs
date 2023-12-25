using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Business.DTOs.CategoryDtos
{
    public class CategoryCreateDto
    {

        public int ParentCategoryId { get; set; }
        public string Title { get; set; }
    }

    public class CategoryCreateDtoValidation : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidation()
        {
            RuleFor(c => c.Title)
              .NotNull()
              .NotEmpty()
              .WithMessage("Bos olmaz")
              .MaximumLength(55)
              .WithMessage("uzunluq 55den cox ola bilmez");
        }
    }
}
