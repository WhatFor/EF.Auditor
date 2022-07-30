namespace WeDo.Audits.UnitTests.Models;

public class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = "";
    
    public Gender Gender { get; set; }
    
    public DateTime DateOfBirth { get; set; }
}

public enum Gender
{
    Female = 0,
    Male = 1,
}