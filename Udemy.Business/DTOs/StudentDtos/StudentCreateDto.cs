using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.CourseDtos;

namespace Udemy.Business.DTOs.StudentDtos
{
    public class StudentCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<CourseCreateDto> CoursesDto { get; set; }
    }
}
