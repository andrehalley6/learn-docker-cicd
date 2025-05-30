using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnDockerCiCd.Domain.Entities;

public class User
{
    [Key]
    public int ID { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = default!;

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = default!;
}