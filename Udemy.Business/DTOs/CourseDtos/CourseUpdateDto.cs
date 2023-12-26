using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;

namespace Udemy.Business.DTOs.CourseDtos
{
    public class CourseUpdateDto: BaseEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
