﻿
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Domain.Entities;
using TVPlus.Infrastructure.Context;
using TVPlus.Infrastructure.Core;


namespace TVPlus.Infrastructure.Repositories
{
    public class ProductoraRepository : BaseRepository<Productora>, IProductoraRepository
    {
        private readonly TVPlusContext _dbContext;
        public ProductoraRepository(TVPlusContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
