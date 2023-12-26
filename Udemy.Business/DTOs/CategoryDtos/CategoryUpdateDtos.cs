using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;

namespace Udemy.Business.DTOs.CategoryDtos
{
    public class CategoryUpdateDtos: BaseEntityDto
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string Title { get; set; }
    }




    public class CategoryUpdateDtosValidation : AbstractValidator<CategoryUpdateDtos>
    {
        public CategoryUpdateDtosValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("It must be filled!");

            RuleFor(c => c.Title)
                .NotNull()
                .WithMessage("It must be filled!")
                .MaximumLength(50)
                .WithMessage("Its length must be lower than 50!");
        }
    }
}
