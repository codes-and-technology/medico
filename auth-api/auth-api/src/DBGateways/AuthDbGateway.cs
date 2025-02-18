﻿using System.Linq.Expressions;
using AuthEntitys;
using AuthInterface;

namespace DBGateways;

public class AuthDbGateway(IUnitOfWork unitOfWork) : BaseDB(unitOfWork), IAuthDBGateway
{
    public async Task UpdateAsync(AuthEntity entity)
    {
        await Uow.Auths.UpdateAsync(entity);
    }

    public async Task<AuthEntity> FindByIdAsync(Guid id)
    {
        return await Uow.Auths.FindByIdAsync(id);
    }

    public async Task<AuthEntity> FirstOrDefaultAsync(Expression<Func<AuthEntity, bool>> predicate)
    {
        return await Uow.Auths.FirstOrDefaultAsync(predicate);
    }
}
