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

        public int ParentCategoryId { get; set; }
        public string Title { get; set; }
    }
}
