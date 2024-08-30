using System.Text.Json.Serialization;

namespace Domain;

public class Dog 
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public Gender Gender {get; set;}
}