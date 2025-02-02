using Entitys;
using Presenters;

namespace Gateways.Queue
{
    public interface IUpdateContactGateway
    {
        Task<UpdateResult<ContactEntity>> UpdateAsync(ContactEntity entity);
    }
}
