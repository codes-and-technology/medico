using Presenters;
using Entitys;

namespace UseCases.Update
{
    public class UpdateContactUseCase : IUpdateContactUseCase
    {
        public UpdateResult<ContactEntity> Update(ContactEntity entity)
        {
            var result = new UpdateResult<ContactEntity>(entity);
            result.Valid(entity);

            if (entity.PhoneRegion?.Id == Guid.Empty)
                result.Errors.Add("O DDD deve ser informado");

            return result;
        }
    }
}
