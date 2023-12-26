using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Business.DTOs.BaseDtos;

namespace Udemy.Business.DTOs.TeacherDtos
{
    public class TeachetUpdateDto: BaseEntityDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }
    }
}
