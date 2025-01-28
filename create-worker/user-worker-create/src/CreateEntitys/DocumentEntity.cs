namespace CreateEntitys;

public class DocumentEntity : EntityBase
{
    public int TypeDocumentId { get; set; }
    public string Value { get; set; }
    public Guid UserId { get; set; }
    public string Region { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}