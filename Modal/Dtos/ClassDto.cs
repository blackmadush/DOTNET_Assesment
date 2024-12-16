using System.Collections.Generic;

namespace Model.Dtos
{
    public class ClassDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public string TeacherInCharge { get; set; }
        public ICollection<StudentDto> Students { get; set; }
    }
}