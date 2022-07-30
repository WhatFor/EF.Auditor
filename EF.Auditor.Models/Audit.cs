using System.ComponentModel.DataAnnotations;

namespace EF.Auditor.Models;

public class Audit
{
    [Key]
    public double Id { get; set; }
}