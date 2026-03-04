namespace BakerySystem.Domain;

public class Material
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public BaseUnit BaseUnit { get; set; }

}
