using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;
using Udemy.Business.DTOs.CourseDtos;

namespace Udemy.Business.DTOs.StudentDtos
{
    public class StudentGetDto: BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<CourseGetDto> CoursesDto { get; set; }
    }
}
