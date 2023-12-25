using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Common;

namespace Udemy.Core.Entities
{
    public class StudentsCourse:BaseAuditableEntity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course course { get; set; }
        public Student Student { get; set; }
    }
}
