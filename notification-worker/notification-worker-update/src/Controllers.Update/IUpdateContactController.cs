using Presenters;
using Entitys;

namespace Controllers.Update
{
    public interface IUpdateContactController
    {
        Task<UpdateResult<ContactEntity>> UpdateAsync(ContactEntity entity);
    }
}
