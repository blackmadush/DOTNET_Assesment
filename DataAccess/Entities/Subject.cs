using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string Code { get; set; } = null!;

    [StringLength(100)]
    public string? Teacher { get; set; }

    [ForeignKey("SubjectId")]
    [InverseProperty("Subjects")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
