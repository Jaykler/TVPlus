
using TVPlus.Application.Interfaces.Repositories;
using TVPlus.Domain.Entities;
using TVPlus.Infrastructure.Context;
using TVPlus.Infrastructure.Core;

namespace TVPlus.Infrastructure.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        private readonly TVPlusContext _dbContext;

        public  GeneroRepository (TVPlusContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

      
    }
}
