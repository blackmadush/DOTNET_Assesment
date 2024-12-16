using System.Collections.Generic;

namespace Model.Dtos
{
    public class SubjectDto
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Teacher { get; set; }
        public ICollection<StudentDto> Students { get; set; }
    }
}