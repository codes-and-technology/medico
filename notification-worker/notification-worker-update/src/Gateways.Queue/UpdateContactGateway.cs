using Entitys;
using Presenters;
using Controllers.Update;

namespace Gateways.Queue
{
    public class UpdateContactGateway(IUpdateContactController updateContactController) : IUpdateContactGateway
    {
        private readonly IUpdateContactController _updateContactController = updateContactController;

        public async Task<UpdateResult<ContactEntity>> UpdateAsync(ContactEntity entity)
        {
            return await _updateContactController.UpdateAsync(entity);
        }
    }
}
