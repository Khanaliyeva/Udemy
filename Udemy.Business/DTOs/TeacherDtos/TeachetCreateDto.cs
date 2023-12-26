using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;
using Udemy.Core.Entities;

namespace Udemy.Business.DTOs.TeacherDtos
{
    public class TeachetCreateDto: BaseAuditableEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
