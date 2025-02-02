﻿using Microsoft.EntityFrameworkCore;
using Entitys;

namespace DataBase.SqlServer;

public class PhoneRegionRepository(ApplicationDbContext context) : Repository<PhoneRegionEntity>(context), IPhoneRegionRepository
{
    public async Task<PhoneRegionEntity> GetByRegionNumberAsync(short number) => await context.PhoneRegions.Where(w => w.RegionNumber == number).FirstOrDefaultAsync();
}
