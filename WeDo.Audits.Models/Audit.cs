using System.ComponentModel.DataAnnotations;

namespace WeDo.Audits.Models;

public class Audit
{
    [Key]
    public double Id { get; set; }
}