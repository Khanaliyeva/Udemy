using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;
using Udemy.Business.DTOs.StudentDtos;
using Udemy.Business.DTOs.TeacherDtos;

namespace Udemy.Business.DTOs.CourseDtos
{
    public class CourseGetDto: BaseAuditableEntityDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public ICollection<StudentGetDto>? StudentsDto { get; set; }
        public TeacherGetDto? TeacherDto { get; set; }
    }
}
