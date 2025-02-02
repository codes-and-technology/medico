using Presenters;
using Entitys;

namespace UseCases.Update
{
    public interface IUpdateContactUseCase
    {
        UpdateResult<ContactEntity> Update(ContactEntity entity);
    }
}
