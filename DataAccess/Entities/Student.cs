using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public int? ClassId { get; set; }

    [ForeignKey("ClassId")]
    [InverseProperty("Students")]
    public virtual Class? Class { get; set; }

    [ForeignKey("StudentId")]
    [InverseProperty("Students")]
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
