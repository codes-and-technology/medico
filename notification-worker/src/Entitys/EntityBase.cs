namespace Entitys;

public class EntityBase
{
    public string Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
