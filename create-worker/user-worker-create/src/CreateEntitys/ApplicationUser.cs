using Microsoft.AspNetCore.Identity;

namespace CreateEntitys;

public class ApplicationUser : IdentityUser<Guid>
{
    public virtual ICollection<DocumentEntity> Documents { get; set; } = new List<DocumentEntity>();

}
