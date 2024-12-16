using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class Class
{
    [Key]
    [Column("ClassID")]
    public int ClassId { get; set; }

    [StringLength(100)]
    public string ClassName { get; set; } = null!;

    public int Grade { get; set; }

    [StringLength(100)]
    public string? TeacherInCharge { get; set; }

    [InverseProperty("Class")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
