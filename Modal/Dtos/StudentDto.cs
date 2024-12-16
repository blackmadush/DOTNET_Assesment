using System.Collections.Generic;

namespace Model.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }
        public ICollection<SubjectDto> Subjects { get; set; }
    }
}